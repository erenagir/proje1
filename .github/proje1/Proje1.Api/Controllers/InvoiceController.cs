using Microsoft.AspNetCore.Mvc;
using Proje1.Aplication.Models.Dtos.Company;
using Proje1.Aplication.Models.Dtos.Invoice;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.RequestModels.Company;
using Proje1.Aplication.Models.RequestModels.Invoices;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;

namespace Proje1.Api.Controllers
{
    [ApiController]
    [Route("invoice")]
    public class InvoiceController : ControllerBase
    {

        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<InvoiceDto>>>> GetAllInvoices()
        {
            var item = _service.GetAllInvoice();
            return Ok(item);
        }


        [HttpGet("GetByCompany/{companyId}")]
        public async Task<ActionResult<Result<List<InvoiceDto>>>> GetInvoiceByCompany(int companyId)
        {
            var item = _service.GetInvoiceByCompany(new GetInvoiceVM { Id = companyId });
            return Ok(item);
        }
        [HttpGet("getByDepartment/{departmentId}")]
        public async Task<ActionResult<Result<List<InvoiceDto>>>> getInvoiceByDepartment(int departmentId)
        {
            var item = _service.GetInvoiceByDepartment(new GetInvoiceVM { Id = departmentId });
            return Ok(item);
        }
        [HttpGet("getByRequest/{requestId}")]
        public async Task<ActionResult<Result<List<InvoiceDto>>>> getInvoiceByRequest(int requestId)
        {
            var item = _service.GetInvoiceByRequestForm(new GetInvoiceVM { Id = requestId });
            return Ok(item);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateCompany(CreateInvoiceVM createInvoiceVM)
        {
            var item = await _service.CreateInvoice(createInvoiceVM);
            return Ok(item);
        }
    }



}
