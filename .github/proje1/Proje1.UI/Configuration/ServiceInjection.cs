using Proje1.UI.Services.Abstraction;
using Proje1.UI.Services.Implementation;

namespace Ahlatci.Shop.UI.Configurations
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IRestService, RestService>();
            services.AddScoped<ILoggedUserService, LoggedUserService>();
            
            return services;
        }
    }
}
