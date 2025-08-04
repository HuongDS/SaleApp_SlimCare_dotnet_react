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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The dbContext<see cref="SlimCareDbContext"/></param>
        public OrderRepository(SlimCareDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _dbContext.Orders
                .Where(o => o.UserId == userId && o.Delete_At == DateTime.MinValue)
                .ToListAsync();
        }
        public async Task<bool> CheckUserIdExist(int userId)
        {
            return await _dbContext.Users.AnyAsync(u => u.Id == userId && u.Delete_At == DateTime.MinValue);
        }
        public async Task<bool> CheckAddressIdExist(int addressId)
        {
            return await _dbContext.Addresses.AnyAsync(u => u.Id == addressId && u.Delete_At == DateTime.MinValue);
        }
    }
}