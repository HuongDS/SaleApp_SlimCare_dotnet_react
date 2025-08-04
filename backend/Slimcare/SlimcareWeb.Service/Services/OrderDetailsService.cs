using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interface;
using SlimcareWeb.Service.Dtos.OrderDetails;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareWeb.Service.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;

        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
        {
            this._orderDetailsRepository = orderDetailsRepository;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<OrderDetails>> GetAllAsync()
        {
            return await _orderDetailsRepository.GetAllAsync();
        }
        public async Task<OrderDetails?> GetByIdAsync(int id)
        {
            return await _orderDetailsRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<OrderDetails>> GetByOrderIdAsync(int orderId)
        {
            return await _orderDetailsRepository.GetOrderDetailsByOrderIdAsync(orderId);
        }
        public async Task<IEnumerable<OrderDetails>> GetAllProductAsync(int id)
        {
            return await _orderDetailsRepository.GetAllProductAsync(id);
        }
        public async Task AddAsync(CreateOrderDetailsDto data)
        {
            var checkOrderId = await _orderDetailsRepository.CheckOrderIdExist(data.OrderId);
            var checkProductId = await _orderDetailsRepository.CheckProductIdExist(data.ProductId);
            if (!checkOrderId || !checkProductId)
            {
                throw new Exception("OrderId or ProductId not exist.");
            }
            if (data.Quantity < 1)
            {
                throw new Exception("Quantity must be greater than 0.");
            }
            var orderDetails = _mapper.Map<OrderDetails>(data);
            orderDetails.Total_Price = orderDetails.Quantity * orderDetails.Product.Price;
            await _orderDetailsRepository.AddAsync(orderDetails);
        }
        public async Task UpdateAsync(int id, int quantity)
        {
            var orderDetails = await _orderDetailsRepository.GetByIdAsync(id);
            if (orderDetails == null)
            {
                throw new Exception("Not Found OrderDetails with Id: " + id);
            }
            orderDetails.Quantity = quantity;
            orderDetails.Total_Price = orderDetails.Quantity * orderDetails.Product.Price;
            await _orderDetailsRepository.UpdateAsync(orderDetails);
        }
        public async Task<OrderDetails> SoftDeleteAsync(int id)
        {
            var orderDetails = await _orderDetailsRepository.GetByIdAsync(id);
            if (orderDetails == null)
            {
                throw new Exception("Not Found OrderDetails with Id: " + id);
            }
            await _orderDetailsRepository.SoftDeleteAsync(id);
            return orderDetails;
        }
    }
}
