using Microsoft.AspNetCore.Mvc;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;

namespace Proje1.Api.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
       
        private readonly IProductSevice _productSevice;

        public ProductController(IProductSevice productSevice)
        {
            _productSevice = productSevice;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<ProductDto>>>> GetAllProduct()
        {
          var products=  _productSevice.GetAllProducts();
          return Ok(products);
        }
        [HttpGet("getByDepartment/{departmentId}")]
        public async Task<ActionResult<Result<List<ProductDto>>>> GetProductsByDepartment(int departmentId)
        {
            var products =await _productSevice.GetAllProductsByDepartment(new GetProductVM { Id = departmentId });
            return Ok(products);
        }
        [HttpGet("getbyCompany/{companyId}")]
        public async Task<ActionResult<Result<List<ProductDto>>>> GetProductsByCompany(int companyId)
        {
            var products = _productSevice.GetAllProductsByCompany(new GetProductVM { Id = companyId });
            return Ok(products);
        }
        [HttpPost("Create")]
        public async Task<ActionResult<Result<int>>> CreateProduct(CreateProductVM createProductVM)
        {
          var productId= await _productSevice.CreateProduct(createProductVM);  
            return Ok(productId);
        }

        [HttpPut("UseProduct")]
        public async Task<ActionResult<Result<int>>> UseProduct(UpdateProductVM updateProductVM)
        {
            var item = await _productSevice.UseProduct(updateProductVM);
            return Ok(item);
        }
        [HttpPut("AddProduct")]
        public async Task<ActionResult<Result<int>>> AddProduct(UpdateProductVM updateProductVM)
        {
            var item = await _productSevice.AddProduct(updateProductVM);
            return Ok(item);
        }
        [HttpDelete("delete/{Id}")]
        public async Task<ActionResult<Result<int>>> DeleteOffer(int Id)
        {
            var item = await _productSevice.DeleteProduct(new DeleteProductVM { Id = Id });
            return Ok(item);
        }

    }
}