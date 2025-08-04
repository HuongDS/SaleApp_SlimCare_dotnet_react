using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interface;

namespace SlimcareWeb.DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SlimCareDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> CheckCategoryExist(string categoryName)
        {
            var check = await _dbContext.Categories.AnyAsync(c => c.Name.Equals(categoryName));
            return check;
        }
    }
}
