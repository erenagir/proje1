using Microsoft.AspNetCore.Authorization;
using Proje1.UI.Models;

namespace Proje1.UI.Authorization
{
    public class RoleAccessRequirement : IAuthorizationRequirement
    {
        public Roles[] Roles { get; set; }

        public RoleAccessRequirement(params Roles[] roles)
        {
            Roles = roles;
        }
    }
}
