using Microsoft.AspNetCore.Mvc;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.Order;
using SlimcareWeb.Service.Dtos.OrderDetails;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            this._orderDetailsService = orderDetailsService;
        }
        [HttpGet("/GetOrderDetails")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetAllAsync()
        {
            return Ok(await _orderDetailsService.GetAllAsync());
        }
        [HttpGet("/GetOrderDetails/{id}")]
        public async Task<ActionResult<OrderDetails>> GetByIdAsync(int id)
        {
            var orderDetails = await _orderDetailsService.GetByIdAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }
        [HttpGet("/GetOrderDetailsByOrderId/{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetByOrderIdAsync(int orderId)
        {
            var orderDetails = await _orderDetailsService.GetByOrderIdAsync(orderId);
            if (orderDetails == null || !orderDetails.Any())
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }
        [HttpGet("/GetAllProducts")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetAllProductAsync(int id)
        {
            return Ok(await _orderDetailsService.GetAllProductAsync(id));
        }
        [HttpPost("/AddOrderDetails")]
        public async Task AddAsync(CreateOrderDetailsDto data)
        {
            await _orderDetailsService.AddAsync(data);
        }
        [HttpPut("/UpdateOrderDetails")]
        public async Task UpdateAsync(int id, int quantity)
        {
            await _orderDetailsService.UpdateAsync(id, quantity);
        }
        [HttpDelete("/DeleteOrderDetails")]
        public async Task<ActionResult<OrderDetails>> SoftDeleteAsync(int id)
        {
            var orderDetails = await _orderDetailsService.SoftDeleteAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }
    }
}
