using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proje1.UI.Models;
using Proje1.UI.Models.Dtos.Company;
using Proje1.UI.Services.Abstraction;
using System.Net;

namespace Proje1.UI.Controllers
{
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

        public async Task<IActionResult> List()
        {
            



            //Apiye istek at
            //category/get
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
