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
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(SlimCareDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Review>> GetAllByProductIdAsync(int productId)
        {
            return await _dbSet
                .Where(x => x.ProductId == productId && x.Delete_At == DateTime.MinValue)
                .ToListAsync();
        }
        public async Task<bool> CheckProductIdExist(int productId)
        {
            return await _dbContext.Products.AnyAsync(p => p.Id == productId && p.Delete_At == DateTime.MinValue);
        }
    }
}
