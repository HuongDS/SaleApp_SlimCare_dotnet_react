
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.Order;

namespace SlimcareWeb.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderViewDto> AddAsync(CreateOrderDto data);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetByUserIdAsync(int userId);
        Task<Order> SoftDeleteAsync(int id);
        Task<OrderViewDto> UpdateAsync(UpdateOrderDto data);
    }
}
