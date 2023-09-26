using Service_Layer.Models;

namespace Service_Layer.IServices
{
    public interface IOrderService
    {
        IEnumerable<OrderServiceModel> GetAllOrders();
        OrderServiceModel GetOrderById(int id);
        void AddOrder(OrderServiceModel order);
        void UpdateOrder(OrderServiceModel order);
        void RemoveOrder(int id);
    }
}
