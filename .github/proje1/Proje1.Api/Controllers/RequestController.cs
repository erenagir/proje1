using Microsoft.AspNetCore.Mvc;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.Dtos.RequestForm;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Models.RequestModels.RequestForm;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;

namespace Proje1.Api.Controllers
{
    [ApiController]
    [Route("request")]
    public class RequestController : ControllerBase
    {
       
        private readonly IRequestFormService _requestFormService;

        public RequestController(IRequestFormService requestFormService)
        {
            _requestFormService = requestFormService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<RequestDto>>>> GetAllRequest()
        {
            var item = _requestFormService.GetAllRequest();
            return Ok(item);
        }

        [HttpGet("getByPending/{departmentId}")]
        public async Task<ActionResult<Result<List<RequestDto>>>> GetRequestByDepartment(int departmentId)
        {
            var item = await _requestFormService.GetRequestByDepartment(new GetRequestVM { Id= departmentId ,Status=Status.pending});
            return Ok(item);
        }
        [HttpGet("getByApproved/{departmentId}")]
        public async Task<ActionResult<Result<List<RequestDto>>>> GetRequestByDepartmentOk(int departmentId)
        {
            var item = await _requestFormService.GetRequestByDepartment(new GetRequestVM { Id = departmentId, Status = Status.approved });
            return Ok(item);
        }
        [HttpGet("getByPerson")]
        public async Task<ActionResult<Result<List<RequestDto>>>> GetRequestByPerson()
        {
            var item = await _requestFormService.GetRequestByPerson();
            return Ok(item);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<bool>>> CreateRequest(CreateRequestVM requestVM)
        {
            var item = await _requestFormService.CreateRequest(requestVM);
            return Ok(item);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Result<int>>> UpdateRequest(UpdateRequestVM updateRequestVM)
        {
            var item = await _requestFormService.UpdateRequest(updateRequestVM);
            return Ok(item);
        }



    }
}