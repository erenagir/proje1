using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje1.UI.Models;
using Proje1.UI.Models.Dtos.Company;
using Proje1.UI.Models.Dtos.Product;
using Proje1.UI.Models.RequestModels.Company;
using Proje1.UI.Models.RequestModels.Product;
using Proje1.UI.Services.Abstraction;
using System.Net;

namespace Proje1.UI.Controllers
{
    [Authorize(Policy = "Admin")]
    public class ProductController : Controller
    {
        private IRestService _restService;
      
        private readonly ILoggedUserService _loggedUserService;

        public ProductController(IRestService restService, ILoggedUserService loggedUserService)
        {
            _restService = restService;
            _loggedUserService = loggedUserService;
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            createProductVM.DepartmentId = (int)_loggedUserService.DepartmentId;
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(createProductVM);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateProductVM, Result<int>>(createProductVM, "product/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Product");
            }
        }



        public async Task<IActionResult> List()
        {
            var response = await _restService.GetAsync<Result<List<ProductDto>>>($"Product/getByDepartment/{_loggedUserService.DepartmentId}");


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

       
        
        public async Task<IActionResult> UseProduct(int id )
        {
            UpdateProductVM updateProductVM = new UpdateProductVM();
            updateProductVM.Id = id;

            return View(updateProductVM);
        }
        [HttpPost]
        public async Task<IActionResult> UseProduct(UpdateProductVM updateProductVM)
        {
            var response = await _restService.PutAsync<UpdateProductVM, Result<int>>(updateProductVM, "product/UseProduct");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Product");
            }


           
        }
        public async Task<IActionResult> AddProduct(int id)
        {
            UpdateProductVM updateProductVM = new UpdateProductVM();
            updateProductVM.Id = id;

            return View(updateProductVM);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(UpdateProductVM updateProductVM)
        {
            var response = await _restService.PutAsync<UpdateProductVM, Result<int>>(updateProductVM, "product/AddProduct");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Product");
            }



        }


    }
}
