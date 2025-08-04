using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.DataAccess.Interface;
using SlimcareWeb.Service.Dtos.Order;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareWeb.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }
        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
        {
            return await _orderRepository.GetOrdersByUserIdAsync(userId);
        }
        public async Task<OrderViewDto> AddAsync(CreateOrderDto data)
        {
            var checkUserId = await _orderRepository.CheckUserIdExist(data.UserId);
            var checkAddressId = await _orderRepository.CheckAddressIdExist(data.AddressId);
            if (!checkUserId || !checkAddressId)
            {
                throw new Exception("UserId or AddressId not exist.");
            }
            var order = _mapper.Map<Order>(data);
            await _orderRepository.AddAsync(order);
            return _mapper.Map<OrderViewDto>(order);
        }
        public async Task<OrderViewDto> UpdateAsync(UpdateOrderDto data)
        {
            var order = await _orderRepository.GetByIdAsync(data.Id);
            if (order == null)
            {
                throw new Exception("Not Found Order with Id: " + data.Id);
            }
            order = _mapper.Map<Order>(data);
            await _orderRepository.UpdateAsync(order);
            return _mapper.Map<OrderViewDto>(order);
        }
        public async Task<Order> SoftDeleteAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new Exception("Not Found Order with Id: " + id);
            }
            await _orderRepository.SoftDeleteAsync(id);
            return order;
        }
    }
}