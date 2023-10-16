using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje1.UI.Models;
using Proje1.UI.Models.Dtos.Offers;
using Proje1.UI.Models.Dtos.RequestForm;
using Proje1.UI.Models.RequestModels.Invoices;
using Proje1.UI.Models.RequestModels.Offers;
using Proje1.UI.Models.RequestModels.RequestForm;
using Proje1.UI.Services.Abstraction;
using System.Diagnostics;
using System.Net;

namespace Proje1.UI.Controllers
{
    [Authorize(Policy = "Admin")]
    public class InvoiceController : Controller
    {


        private IRestService _restService;
        private readonly ILoggedUserService _loggedUserService;
        private readonly IMapper _mapper;
        public InvoiceController(IRestService restService, ILoggedUserService loggedUserService, IMapper mapper)
        {
            _restService = restService;

            _loggedUserService = loggedUserService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Create(int id)
        {
            var createOffer = new CreateInvoiceVM() { RequestFormId = id };

            return View(createOffer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInvoiceVM createInvoiceVM)
        {
            createInvoiceVM.DepartmentId =(int)_loggedUserService.DepartmentId;
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(createInvoiceVM);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateInvoiceVM, Result<int>>(createInvoiceVM, "invoice/create");
            
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {

                return RedirectToAction("ListOkOffer", "invoice");

            }
        }



        [HttpGet]
        public async Task<IActionResult> ListOkOffer()
        {
            var response = await _restService.GetAsync<Result<List<OfferDto>>>($"offer/getOfferbyOk");


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

