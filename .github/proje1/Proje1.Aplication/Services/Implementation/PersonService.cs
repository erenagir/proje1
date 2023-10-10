using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Proje1.Aplication.Exceptions;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;
using Proje1.Domain.UWork;
using Proje1.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly IConfiguration _configuration;
        private readonly IUWork _uWork;
        private readonly IMapper _mapper;

        public PersonService(IConfiguration configuration, IUWork uWork, IMapper mapper)
        {
            _configuration = configuration;
            _uWork = uWork;
            _mapper = mapper;
        }

        public async Task<Result<List<PersonDto>>> GetAllPersons()
        {
            var result=new Result<List<PersonDto>>();
            var personEntites=await _uWork.GetRepository<Person>().GetAllAsync();
            var personDtos= personEntites.ProjectTo<PersonDto>(_mapper.ConfigurationProvider).ToList();
            result.Data= personDtos;
            return result;
        }

        public async Task<Result<TokenDto>> Login(LoginVM loginVM)
        {
            var result = new Result<TokenDto>();
            var hashedPassword = CipherUtils.EncryptString(_configuration["AppSettings:SecretKey"], loginVM.Password);
            var existsPerson = await _uWork.GetRepository<Person>().GetSingleByFilterAsync(x => x.UserName == loginVM.UserName && hashedPassword == x.Password);
            if (existsPerson == null)
            //exception eklenecek 
            {
                throw new Exception("kullanıcı bulunamadı");
            }

            var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
            var expireDate = DateTime.Now.AddMinutes(expireMinute);
            var tokenString = GenerateJwtToken(existsPerson, expireDate);
            result.Data = new TokenDto
            {
                Token = tokenString,
                Expiredate = expireDate,
            };
            return result;
        }

        public async Task<Result<bool>> Register(ReisterVM reisterVM)
        {
            var result = new Result<bool>();
            if (await _uWork.GetRepository<Person>().AnyAsync(x => x.UserName == reisterVM.UserName))
            {
                throw new AlreadyExistsException("kullanıcı adı kullanılmaktadır");

            }
            //Gelen model person türüne maplandi.
            var userEntity = _mapper.Map<Person>(reisterVM);
            
           
            //Kullanıcının parolasını şifreleyerek kaydedelim.
            userEntity.Password = CipherUtils
                .EncryptString(_configuration["AppSettings:SecretKey"], userEntity.Password);

            

            _uWork.GetRepository<Person>().Add(userEntity);
            
            result.Data = await _uWork.ComitAsync($"{userEntity.Id} kimlik numaralı kullanıcı oluşturuldu");

            return result;




            
        }

        private string GenerateJwtToken(Person account, DateTime expireDate)
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
                    new Claim(ClaimTypes.Name, account.UserName),
                    new Claim(ClaimTypes.Role,account.Role.ToString()),
                    new Claim(ClaimTypes.PrimarySid, account.departmantId.ToString()),

                    new Claim(ClaimTypes.Sid, account.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
