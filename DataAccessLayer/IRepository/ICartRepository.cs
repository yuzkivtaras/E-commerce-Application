using DataAccessLayer.Entities;

namespace DataAccessLayer.IRepository
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCartByCustomerId(int customerId);
        void AddItemToCart(CartItem cartItem);
        void UpdateCartItem(CartItem cartItem);
        CartItem GetItemById(int id);
        void RemoveCartItem(CartItem cartItem);
    }
}
