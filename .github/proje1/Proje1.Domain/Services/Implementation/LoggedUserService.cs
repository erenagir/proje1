﻿using Microsoft.AspNetCore.Http;
using Proje1.Domain.Entities;
using Proje1.Domain.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Domain.Services.Implementation
{
    public class LoggedUserService : ILoggedUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoggedUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string Username => GetClaim(ClaimTypes.Name) != null ? GetClaim(ClaimTypes.Name) : null;

        public string Email => GetClaim(ClaimTypes.Email) != null ? GetClaim(ClaimTypes.Email) : null;
        public Roles? Role => GetClaim(ClaimTypes.Role) != null ? (Roles)Enum.Parse(typeof(Roles), GetClaim(ClaimTypes.Role)) : null;

        public int? UserId => GetClaim(ClaimTypes.Sid) != null ? int.Parse(GetClaim(ClaimTypes.Sid)) : null;

        public int? DepartmentId => GetClaim(ClaimTypes.PrimarySid) != null ? int.Parse(GetClaim(ClaimTypes.PrimarySid)) : null;

      
        
        private string GetClaim(string claimType)
        {
            return _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        }
    }
}
