using Microsoft.AspNetCore.Mvc;
using Proje1.Aplication.Models.Dtos.Offers;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.Dtos.RequestForm;
using Proje1.Aplication.Models.RequestModels.Offers;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Models.RequestModels.RequestForm;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;

namespace Proje1.Api.Controllers
{
    [ApiController]
    [Route("offer")]
    public class OfferController : ControllerBase
    {
       
        private readonly IOfferService _service;

        public OfferController(IOfferService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<OfferDto>>>> GetAllOffer(GetAllOfferByRequestVM getAllOfferByRequestVM)
        {
            var item = _service.GetAllOfferByRequest(getAllOfferByRequestVM);
            return Ok(item);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateOffer(CreateOfferVM offerVM)
        {
            var item = await _service.CreateOffer(offerVM);
            return Ok(item);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Result<int>>> UpdateRequest(UpdateOfferVM updateOfferVM)
        {
            var item = await _service.UpdateOffer(updateOfferVM);
            return Ok(item);
        }



    }
}