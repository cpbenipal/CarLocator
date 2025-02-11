using CLIMFinders.Infrastructure.Data;
using CLIMFinders.Web.ServiceExtension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Web;
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

    var app = builder.Build();

    // Configure Middleware Pipeline
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseMiddleware<JwtCookieMiddleware>(); // Custom Middleware to Extract JWT from Cookies

    app.UseRouting();
    app.UseCors("AllowAll");
    app.UseAuthentication();

    // Redirect Unauthorized Requests
    app.UseStatusCodePages(async context =>
    {
        if (context.HttpContext.Response.StatusCode == 403) // Forbidden
        {
            context.HttpContext.Response.Redirect("/Unauthorized");
        }
    });

    app.UseAuthorization();
    app.UseStaticFiles();

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
