using Microsoft.AspNetCore.Mvc;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.Order;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        [HttpGet("/GetOrder")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllAsync()
        {
            return Ok(await _orderService.GetAllAsync());
        }
        [HttpGet("/GetOrder/{id}")]
        public async Task<ActionResult<Order>> GetByIdAsync(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpGet("/GetOrderByUserId/{userId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetByUserIdAsync(int userId)
        {
            var orders = await _orderService.GetByUserIdAsync(userId);
            if (orders == null || !orders.Any())
            {
                return NotFound();
            }
            return Ok(orders);
        }

        [HttpPost("/AddOrder")]
        public async Task<ActionResult<OrderViewDto>> AddAsync(CreateOrderDto data)
        {
            try
            {
                var order = await _orderService.AddAsync(data);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/UpdateOrder")]
        public async Task<ActionResult<OrderViewDto>> UpdateAsync(UpdateOrderDto data)
        {
            try
            {
                var order = await _orderService.UpdateAsync(data);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("/DeleteOrder")]
        public async Task<ActionResult<Order>> SoftDeleteAsync(int id)
        {
            try
            {
                var order = await _orderService.SoftDeleteAsync(id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
