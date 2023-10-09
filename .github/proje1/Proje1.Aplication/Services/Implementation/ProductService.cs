using AutoMapper;
using AutoMapper.QueryableExtensions;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;
using Proje1.Domain.UWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Implementation
{
    public class ProductService : IProductSevice
    {
        private readonly IUWork _uWork;
        private readonly IMapper _mapper;
        public ProductService(IUWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> CreateProduct(CreateProductVM createProductVM)
        {
            var result = new Result<int>();
            var productEntity = _mapper.Map<Product>(createProductVM);
            _uWork.GetRepository<Product>().Add(productEntity);
            await _uWork.ComitAsync($"{productEntity.Id} kimlik numaralı ürün oluşturuldu");
            result.Data = productEntity.Id;
            return result;
        }

        public async Task<Result<List<ProductDto>>> GetAllProductsByDepartment(GetAllProductByDepartmentVM getAllProductByDepartmentVM )
        {
            var result = new Result<List<ProductDto>>();
            var products = await _uWork.GetRepository<Product>().GetByFilterAsync(x=>x.DepartmentId==getAllProductByDepartmentVM.DepartmentId);
            var productDtos = products.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = productDtos;
            return result;

        }

        public async Task<Result<bool>> UseProduct(UpdateProductVM updateProductVM)
        {
            var result = new Result<bool>();
            var productEntity = await _uWork.GetRepository<Product>().GetById(updateProductVM.Id);
            productEntity.Stock -= updateProductVM.Stock;
            _uWork.GetRepository<Product>().Update(productEntity);
            result.Data = await _uWork.ComitAsync($"{productEntity.Id} kimlik numaralı ürün kullanıldı");
            return result;
        }
        public async Task<Result<bool>> AddProduct(UpdateProductVM updateProduct)
        {
            var result = new Result<bool>();
            var productEntity = await _uWork.GetRepository<Product>().GetById(updateProduct.Id);
            productEntity.Stock += updateProduct.Stock;
            _uWork.GetRepository<Product>().Update(productEntity);
            result.Data = await _uWork.ComitAsync($"{productEntity.Id} kimlik numaralı ürün stok eklemsi yapıldı" );
            return result;
        }
    }
}
