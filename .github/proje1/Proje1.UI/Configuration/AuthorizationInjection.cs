using Microsoft.AspNetCore.Authorization;
using Proje1.UI.Authorization;
using Proje1.UI.Models;

namespace Ahlatci.Shop.UI.Configurations
{
    public static class AuthorizationInjection
    {
        public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, SessionBasedAccessHandler>();

            services.AddAuthorization(opt =>
            {

                //deneme
                opt.AddPolicy("Admin", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Roles.admin));
                });

                opt.AddPolicy("User", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Roles.request));
                });

                opt.AddPolicy("AdminOrUser", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Roles.recive, Roles.management));
                });

            });

            return services;
        }
    }
}
