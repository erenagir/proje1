using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje1.UI.Models;
using Proje1.UI.Models.Dtos.Company;
using Proje1.UI.Models.RequestModels.Company;
using Proje1.UI.Services.Abstraction;
using System.Net;

namespace Proje1.UI.Controllers
{
    [Authorize(Policy = "Admin")]
    public class CompanyController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public CompanyController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            ViewBag.Header = "Şirket İşlemleri";
            ViewBag.Title = "Yeni Şirket Oluştur";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyVM createCompanyVM)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(createCompanyVM);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateCompanyVM, Result<int>>(createCompanyVM, "company/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Company");
            }
        }



        public async Task<IActionResult> List()
        {
            var response = await _restService.GetAsync<Result<List<CompanyDto>>>("company/get");


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
