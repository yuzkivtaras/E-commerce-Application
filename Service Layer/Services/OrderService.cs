using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Service_Layer.IServices;
using Service_Layer.Models;

namespace Service_Layer.Services 
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderServiceModel> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderServiceModel>>(orders);
        }

        public OrderServiceModel GetOrderById(int id)
        {
            var order = _orderRepository.GetById(id);
            return _mapper.Map<OrderServiceModel>(order);
        }

        public void AddOrder(OrderServiceModel orderServiceModel)
        {
            var order = _mapper.Map<Order>(orderServiceModel);
            _orderRepository.Add(order);
        }

        public void UpdateOrder(OrderServiceModel orderServiceModel)
        {
            var order = _mapper.Map<Order>(orderServiceModel);
            _orderRepository.Update(order);
        }

        public void RemoveOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            _orderRepository.Remove(order);
        }
    }
}
