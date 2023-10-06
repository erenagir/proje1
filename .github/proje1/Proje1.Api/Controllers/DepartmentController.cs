using Microsoft.AspNetCore.Mvc;
using Proje1.Aplication.Models.Dtos.Company;
using Proje1.Aplication.Models.Dtos.Department;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.RequestModels.Company;
using Proje1.Aplication.Models.RequestModels.Department;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;

namespace Proje1.Api.Controllers
{
    [ApiController]
    [Route("department")]
    public class DepartmentController : ControllerBase
    {
       
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService departmentService)
        {
            _service = departmentService;
        }

        [HttpGet("get/{companyId}")]
        public async Task<ActionResult<Result<List<DepartmentDto>>>> GetAllDepartment( int companyId)
        {
            var item = _service.GetAllDepartmentByCompany(new GetAllDepartmentByCompanyVM {CompanyId= companyId });
            return Ok(item);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateCompany(CreateDepartmentVM createDepartmentVM)
        {
            var item = await _service.CreateDepartment(createDepartmentVM);
            return Ok(item);
        }




    }
}