using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.RequestModels;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;
using Proje1.Domain.UWork;
using Proje1.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly IConfiguration _configuration;
        private readonly IUWork _uWork;

        public PersonService(IConfiguration configuration, IUWork uWork)
        {
            _configuration = configuration;
            _uWork = uWork;
        }


        public async Task<Result<TokenDto>> Login(LoginVM loginVM)
        {
            var result = new Result<TokenDto>();
            var hashedPassword = CipperUtils.EncryptString(_configuration["Appsettigs:SecretKey"], loginVM.Password);
            var existsPerson = await _uWork.GetRepository<Account>().GetSingleByFilterAsync(x => x.UserName == loginVM.UserName && hashedPassword == x.Password, "Person");
            if (existsPerson != null)
 //exception eklenecek 
            {
                throw new Exception("kullanıcı bulunamadı");
            }

            var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
            var expireDate= DateTime.Now.AddMinutes(expireMinute);
            var tokenString = GenerateJwtToken(existsPerson, expireDate);
                 result.Data = new TokenDto
                 {
                     Token = tokenString,
                     Expiredate = expireDate,
                 };
            return result;
        }

        public Task<Result<bool>> Register(ReisterVM reisterVM)
        {
            throw new NotImplementedException();
        }
       
        private string GenerateJwtToken(Account account, DateTime expireDate)
        {
            var secretkey = _configuration["Jwt:SigningKey"];
            var ıssuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audiance"];




            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretkey); // appsettings.json içinde JWT ayarlarınızı yapmalısınız

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = audience,
                Issuer = ıssuer,

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,account.UserName),
                    new Claim(ClaimTypes.Role,account.Person.Role.ToString()),
                    new Claim(ClaimTypes.Email,account.Person.Email),

                    new Claim(ClaimTypes.Sid,account.PersonId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
