using AuthApi.Application.Interfaces;
using AuthApi.Infras.Data;
using AuthApi.Infras.Repositories;
using eCommerce.SharedLibrary.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AuthApi.Infras.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {
            // Add database connectivity
            // Add authentication scheme
            SharedServiceContainer.AddSharedServices<AuthenticationDbContext>(services, config, config["MySerilog:FileName"]!);

            // Create Dependency Injection
            services.AddScoped<IUser, UserRepository>();

            return services;
        }

        public static IApplicationBuilder UseInfrastructurePolicy(this IApplicationBuilder app)
        {
            // Register middleware such as:
            // Global Exception: handles external errors
            // Listen to Only Api Gateway: Block all outsider calls;
            SharedServiceContainer.UseSharedPolicies(app);

            return app;
        }
    }
}
