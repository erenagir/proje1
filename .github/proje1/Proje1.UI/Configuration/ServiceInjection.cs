using Proje1.UI.Services.Abstraction;
using Proje1.UI.Services.Implementation;

namespace Proje1.UI.Configurations
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IRestService, RestService>();
            
            return services;
        }
    }
}
