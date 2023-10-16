using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje1.UI.Models;
using Proje1.UI.Models.Dtos.Offers;
using Proje1.UI.Models.Dtos.RequestForm;
using Proje1.UI.Models.RequestModels.Offers;
using Proje1.UI.Models.RequestModels.RequestForm;
using Proje1.UI.Services.Abstraction;
using System.Diagnostics;
using System.Net;

namespace Proje1.UI.Controllers
{
    [Authorize(Policy = "Admin")]
    public class OfferController : Controller
    {


        private IRestService _restService;
        private readonly ILoggedUserService _loggedUserService;
        private readonly IMapper _mapper;
        public OfferController(IRestService restService, ILoggedUserService loggedUserService, IMapper mapper)
        {
            _restService = restService;

            _loggedUserService = loggedUserService;
            _mapper = mapper;
        }

     
        public async Task<IActionResult> Create(int id)
        {
            var createOffer = new CreateOfferVM() { RequestformId = id };

            return View(createOffer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfferVM createOfferVM)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(createOfferVM);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateOfferVM, Result<int>>(createOfferVM, "offer/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {

                return RedirectToAction("ListOkRequest", "Offer");

            }
        }
        public async Task<IActionResult> List(int id)
        {
            var response = await _restService.GetAsync<Result<List<OfferDto>>>($"offer/get/{id}");


            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            else
            {
                return View(response.Data.Data);
            }


        }

        public async Task<IActionResult> ListOkRequest()
        {
            var response = await _restService.GetAsync<Result<List<RequestDto>>>($"request/getByApproved/{_loggedUserService.DepartmentId}");


            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            else
            {
                return View(response.Data.Data);
            }


        }






    }
}

