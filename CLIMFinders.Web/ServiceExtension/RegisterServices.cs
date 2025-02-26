using CLIMFinders.Application.Interfaces;
using CLIMFinders.Application.Services;
using CLIMFinders.Infrastructure.Repositories;
using CLIMFinders.Repositories;

namespace CLIMFinders.Web.ServiceExtension
{
    public static class RegisterServices
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>(); 
            services.AddScoped<IUnitOfWork, UnitOfWorkBase>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IHashManager, HashManager>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStaticSelectOptionService, StaticSelectOptionService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
        }
    }
}
