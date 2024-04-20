using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TradeApp.Application.AddMediator
{
    public static class ServiceCollectionExtencion
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
