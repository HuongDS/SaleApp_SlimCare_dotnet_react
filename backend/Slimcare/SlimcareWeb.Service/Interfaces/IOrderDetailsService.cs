using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.OrderDetails;

namespace SlimcareWeb.Service.Interfaces
{
    internal interface IOrderDetailsService
    {
        Task AddAsync(CreateOrderDetailsDto data);
        Task<OrderDetails> SoftDeleteAsync(int id);
        Task<IEnumerable<OrderDetails>> GetAllAsync();
        Task<OrderDetails?> GetByIdAsync(int id);
        Task<IEnumerable<OrderDetails>> GetByOrderIdAsync(int orderId);
        Task UpdateAsync(int id, int quantity);
    }
}
