using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;

namespace SlimcareWeb.DataAccess.Interface
{
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetails>
    {
        Task<bool> CheckOrderIdExist(int id);
        Task<bool> CheckProductIdExist(int id);
        Task<IEnumerable<OrderDetails>> GetAllProductAsync(int id);
        Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId);
    }
}
