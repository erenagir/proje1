using Newtonsoft.Json;
using Proje1.UI.Models;
using Proje1.UI.Models.Dtos.Person;
using Proje1.UI.Services.Abstraction;
using System.Security.Claims;

namespace Proje1.UI.Services.Implementation
{
    public class LoggedUserService : ILoggedUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        public LoggedUserService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _contextAccessor = httpContextAccessor;
            _configuration = configuration;
        }






        public Roles? Role => GetToken().Role;

        public int? UserId =>GetToken().Id;

        public int? DepartmentId => GetToken().DepartmentId;

        private TokenDto GetToken()
        {
            var sessionKey = _configuration["Application:SessionKey"];
            if (_contextAccessor.HttpContext.Session.GetString(sessionKey) is null)
                return null;
            var tokenDto = JsonConvert.DeserializeObject<TokenDto>(_contextAccessor.HttpContext.Session.GetString(sessionKey));
            return tokenDto;
        }


    }
}
