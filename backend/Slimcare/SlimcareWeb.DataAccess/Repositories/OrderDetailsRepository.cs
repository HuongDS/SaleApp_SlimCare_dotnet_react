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
            return await _dbSet.Where(od => od.OrderId == orderId).ToListAsync();
        }
    }
}
