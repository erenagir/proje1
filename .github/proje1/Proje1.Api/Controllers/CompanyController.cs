using Microsoft.AspNetCore.Mvc;
using Proje1.Aplication.Models.Dtos.Company;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.RequestModels.Company;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;

namespace Proje1.Api.Controllers
{
    [ApiController]
    [Route("company")]
    public class CompanyController : ControllerBase
    {
       
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<CompanyDto>>>> GetAllCompany()
        {
          var item=await  _service.GetAllCompany();
          return Ok(item);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateCompany(CreateCompanyVM createCompanyVM)
        {
          var item= await _service.CreateCompany(createCompanyVM);  
            return Ok(item);
        }

      

    }
}