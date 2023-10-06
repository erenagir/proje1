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
    [Route("requestfrom")]
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