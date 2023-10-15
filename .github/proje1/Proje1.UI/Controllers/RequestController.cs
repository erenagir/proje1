using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje1.UI.Models;
using Proje1.UI.Models.Dtos.RequestForm;
using Proje1.UI.Models.RequestModels.RequestForm;
using Proje1.UI.Services.Abstraction;
using System.Diagnostics;
using System.Net;

namespace Proje1.UI.Controllers
{
    [Authorize(Policy = "Admin")]
    public class RequestController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IRestService _restService;
        private readonly IMapper _mapper;
        private readonly ILoggedUserService _loggedUserService;
        public RequestController(IRestService restService, IMapper mapper, ILoggedUserService loggedUserService)
        {
            _restService = restService;
            _mapper = mapper;
            _loggedUserService = loggedUserService;
        }

        public IActionResult Create()
        {
            
            ViewBag.Header = "talep İşlemleri";
            ViewBag.Title = "Yeni Talep Oluştur";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestVM createRequestVM)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(createRequestVM);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateRequestVM, Result<bool>>(createRequestVM, "request/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
               
                return RedirectToAction("List", "Request");
            }
        }

        public async Task<IActionResult> List()
        {
            var response = await _restService.GetAsync<Result<List<RequestDto>>>("request/getByPerson");


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
        public async Task<IActionResult> ListOk()
        {
            var response = await _restService.GetAsync<Result<List<RequestDto>>>($"request/get/{_loggedUserService.DepartmentId}");


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
        
        public async Task<IActionResult> Accept(int id)
        {

            var request=new UpdateRequestVM();
            request.Status = Status.approved;
            request.Id = id;
            var response = await _restService.PutAsync<UpdateRequestVM, Result<int>>(request, "request/update");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("ListOk", "request");
            }

        }
        public async Task<IActionResult> Refuse(int id)
        {

            var request = new UpdateRequestVM();
            request.Status = Status.refuse;
            request.Id = id;
            var response = await _restService.PutAsync<UpdateRequestVM, Result<int>>(request, "request/update");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("ListOk", "request");
            }

        }

    }
}