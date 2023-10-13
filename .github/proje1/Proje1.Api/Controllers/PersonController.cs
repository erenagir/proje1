using Microsoft.AspNetCore.Mvc;
using Proje1.Aplication.Models.Dtos.Invoice;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.RequestModels.Invoices;
using Proje1.Aplication.Models.RequestModels.Offers;
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
        public async Task<ActionResult<Result<List<PersonDto>>>> GetAllPerson()
        {
          var products=  _personService.GetAllPersons();
          return Ok(products);
        }
        [HttpGet("getByCompany/{companyId}")]
        public async Task<ActionResult<Result<List<PersonDto>>>> getPersonByCompany(int companyId)
        {
            var item = _personService.GetPersonsByCompany(new GetPersonVM { Id = companyId });
            return Ok(item);
        }
        [HttpGet("getByDepartment/{departmentId}")]
        public async Task<ActionResult<Result<List<PersonDto>>>> getPersonByDepartment(int departmentId)
        {
            var item = _personService.GetPersonsByDepartment(new GetPersonVM { Id = departmentId });
            return Ok(item);
        }
        [HttpGet("getById/{ýd}")]
        public async Task<ActionResult<Result<PersonDto>>> GetPersonsById(int ýd)
        {
            var item = _personService.GetPersonsById(new GetPersonVM { Id = ýd });
            return Ok(item);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Result<int>>> UpdateOfferbyStatus(UpdatePersonVM updatePersonVM)
        {
            var item = await _personService.UpdatePerson(updatePersonVM);
            return Ok(item);
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