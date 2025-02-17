using CLIMFinders.Application.DTOs;
using CLIMFinders.Infrastructure.Data;
using CLIMFinders.Web.ServiceExtension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Web;
using Stripe;
using System.Text;

var logger = LogManager.Setup().LoadConfigurationFromFile("NLog.config").GetCurrentClassLogger();
logger.Info("Application is starting...");

try
{
    var builder = WebApplication.CreateBuilder(args);
    var config = builder.Configuration;

    // Configure JWT Authentication Settings
    var jwtSettings = config.GetSection("JwtSettings");
    var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);

    // Enable CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.WithOrigins(jwtSettings["Issuer"])
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
    });

    // Configure Logging with NLog
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Register Services
    builder.Services.ConfigureRepositoryWrapper();

    builder.Services.AddSingleton<IWebHostEnvironment>(builder.Environment);
    builder.Services.AddSingleton<IFileProvider>(
    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
    );
    // Add Controllers and Razor Pages
    builder.Services.AddControllers();
    builder.Services.AddRazorPages();

    // Configure Database
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));

    // Configure JWT Authentication
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(secretKey)
            };
        }); 
    // Configure Authorization Policies
    builder.Services.AddAuthorizationBuilder()
        .AddPolicy("SuperAdminPolicy", policy => policy.RequireRole("SuperAdmin"))
        .AddPolicy("UsersPolicy", policy => policy.RequireRole("Users"))
        .AddPolicy("TowPolicy", policy => policy.RequireRole("Tow"))
        .AddPolicy("ImpoundPolicy", policy => policy.RequireRole("Impound"))
        .AddPolicy("IMCAndTowPolicy", policy => policy.RequireRole("Impound", "Tow"));

    // Register AutoMapper
    builder.Services.AddAutoMapper(typeof(GenericMappingProfile));

    // Add Stripe configuration to DI container
    builder.Services.AddSingleton<IStripeClient>(sp =>
    {
        var stripeSecretKey = builder.Configuration["Stripe:SecretKey"];
        return new StripeClient(stripeSecretKey);
    });


  //  builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
  //  StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

    var app = builder.Build();
   
    app.UseCors("AllowAll");
    app.UseStaticFiles();
    // Configure Middleware Pipeline
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }


    app.UseMiddleware<JwtCookieMiddleware>(); // Custom Middleware to Extract JWT from Cookies

    app.UseRouting();

    app.UseAuthentication();

    // Redirect Unauthorized Requests
    app.UseStatusCodePages(async context =>
    {
        if (context.HttpContext.Response.StatusCode == 403 && !context.HttpContext.Response.HasStarted) // Forbidden
        {
            context.HttpContext.Response.Redirect("/Unauthorized");

        }
        else if (context.HttpContext.Response.StatusCode == 401) 
        {
            context.HttpContext.Response.Redirect("/Login");
        }
        else if (context.HttpContext.Response.StatusCode == 404 && !context.HttpContext.Response.HasStarted)
        {
            context.HttpContext.Response.Redirect("/NotFound");
        }
    });

    app.UseAuthorization();


    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        endpoints.MapRazorPages();
    }); 

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Application startup failed.");
    throw;
}
finally
{
    LogManager.Shutdown(); // Ensure proper shutdown of NLog
}
