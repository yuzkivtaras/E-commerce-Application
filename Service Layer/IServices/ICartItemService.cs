using Service_Layer.Models;

namespace Service_Layer.IServices
{
    public interface ICartItemService
    {
        IEnumerable<CartItemServiceModel> GetAllCartItems();
        CartItemServiceModel GetCartItemById(int id);
        void AddCartItem(CartItemServiceModel cartItem);
        void UpdateCartItem(CartItemServiceModel cartItem);
        void RemoveCartItem(int id);
    }
}
