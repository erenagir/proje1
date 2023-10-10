using Microsoft.AspNetCore.Authorization;
using Proje1.UI.Authorization;
using Proje1.UI.Models;

namespace Proje1.UI.Configurations
{
    public static class AuthorizationInjection
    {
        public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, SessionBasedAccessHandler>();

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Roles.Admin));
                });

                //opt.AddPolicy("User", policy =>
                //{
                //    policy.AddRequirements(new RoleAccessRequirement(Roles.User));
                //});

                //opt.AddPolicy("AdminOrUser", policy =>
                //{
                //    policy.AddRequirements(new RoleAccessRequirement(Roles.Admin, Roles.User));
                //});

            });

            return services;
        }
    }
}
