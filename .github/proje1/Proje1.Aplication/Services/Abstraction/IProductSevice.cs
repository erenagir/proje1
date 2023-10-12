using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Abstraction
{
    public interface IProductSevice
    {
        Task<Result<List<ProductDto>>> GetAllProducts();
        Task<Result<List<ProductDto>>> GetAllProductsByCompany(GetProductVM getProductVM);
        Task<Result<List<ProductDto>>> GetAllProductsByDepartment(GetProductVM getProductVM);
        Task<Result<int>> CreateProduct(CreateProductVM createProductVM);
        Task<Result<bool>> UseProduct(UpdateProductVM UpdateProductVM);
        Task<Result<bool>> AddProduct(UpdateProductVM updateProduct);
        Task<Result<int>> DeleteProduct(DeleteProductVM deleteProductVM);
    }
}
