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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SlimCareDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> CheckProductExist(string productName)
        {
            var check = await _dbContext.Products.AnyAsync(p => p.Name.ToLower().Equals(productName.ToLower()));
            return check;
        }
    }
}
