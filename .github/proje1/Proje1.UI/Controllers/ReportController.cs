using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje1.UI.Models;
using Proje1.UI.Models.Dtos.Company;
using Proje1.UI.Models.Dtos.Report;
using Proje1.UI.Models.RequestModels.Company;
using Proje1.UI.Services.Abstraction;
using System.Net;

namespace Proje1.UI.Controllers
{
    [Authorize(Policy = "Admin")]
    public class ReportController : Controller
    {
        private IRestService _restService;
        private readonly ILoggedUserService _loggedUserService;

      
         public ReportController(IRestService restService, ILoggedUserService loggedUserService)
        {
            _restService = restService;
            _loggedUserService = loggedUserService;
        }

        [HttpGet]
        public async Task<IActionResult> ListByPerson()
        {
            var response = await _restService.GetAsync<Result<List<ReportDto>>>($"report/getbyPerson/{_loggedUserService.UserId}");


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
        [HttpGet]
       
        public async Task<IActionResult> ListByDepartment()
        {
            var response = await _restService.GetAsync<Result<List<ReportDto>>>($"report/getbyDepartment/{_loggedUserService.DepartmentId}");


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
        [HttpGet]
        public async Task<IActionResult> ListByCompany()
        {
            var response = await _restService.GetAsync<Result<List<ReportDto>>>("report/get");


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
