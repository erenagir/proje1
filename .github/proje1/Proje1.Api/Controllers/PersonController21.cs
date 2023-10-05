using Microsoft.AspNetCore.Mvc;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;

namespace Proje1.Api.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : ControllerBase
    {
       
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<ProductDto>>>> GetAllPerson()
        {
          var products=  _personService.GetAllPersons();
          return Ok(products);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<bool>>> CreatePerson(ReisterVM reisterVM)
        {
          var item= await _personService.Register(reisterVM);  
            return Ok(item);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Result<TokenDto>>> Login(LoginVM loginVM)
        {
            var item = await _personService.Login(loginVM);
            return Ok(item);
        }
        


    }
}