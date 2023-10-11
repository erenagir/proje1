using Microsoft.AspNetCore.Mvc;
using Proje1.Aplication.Models.Dtos.Company;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.RequestModels.Company;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Models.RequestModels.Report;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;

namespace Proje1.Api.Controllers
{
    [ApiController]
    [Route("report")]
    public class ReportController : ControllerBase
    {
       
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<CompanyDto>>>> GetAllReport()
        {
          var item=  _service.GetAllReport();
          return Ok(item);
        }
        [HttpGet("getbyPerson/{PersonId}")]
        public async Task<ActionResult<Result<List<CompanyDto>>>> GetReportbyPerson(int PersonId)
        {
            var item = _service.GetReportByPerson(new GetReportVM { Id = PersonId });
            return Ok(item);
        }
        [HttpGet("getbyDepartment/{DepartmentId}")]
        public async Task<ActionResult<Result<List<CompanyDto>>>> GetReportByDepartment(int DepartmentId)
        {
            var item = _service.GetReporByDepartment(new GetReportVM { Id = DepartmentId });
            return Ok(item);
        }




    }
}