using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.Category;

namespace SlimcareWeb.Service.Interfaces
{
    internal interface ICategoryService
    {
        Task<CategoryViewDto> AddAsync(CreateCategoryDto data);
        Task<Category> SoftDeleteAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<CategoryViewDto> UpdateAsync(UpdateCategoryDto data);
    }
}
