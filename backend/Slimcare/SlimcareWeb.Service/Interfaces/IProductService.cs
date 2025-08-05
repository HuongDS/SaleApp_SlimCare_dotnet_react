using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.Product;
using SlimcareWeb.Service.Services;

namespace SlimcareWeb.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductViewDto> AddAsync(CreateProductDto data);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> SoftDeleteAsync(int id);
        Task<ProductViewDto> UpdateAsync(UpdateProductDto data);
    }
}
