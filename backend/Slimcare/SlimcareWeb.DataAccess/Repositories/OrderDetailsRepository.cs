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
    public class OrderDetailsRepository : GenericRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(SlimCareDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _dbSet.Where(od => od.OrderId == orderId && od.Delete_At == DateTime.MinValue).ToListAsync();
        }
        public async Task<bool> CheckOrderIdExist(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id && x.Delete_At == DateTime.MinValue) != null;
        }
        public async Task<bool> CheckProductIdExist(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id && x.Delete_At == DateTime.MinValue) != null;
        }
        public async Task<IEnumerable<OrderDetails>> GetAllProductAsync(int id)
        {
            return await _dbSet.Include(x => x.Product).Where(x => x.Id == id).ToListAsync();
        }
    }
}
