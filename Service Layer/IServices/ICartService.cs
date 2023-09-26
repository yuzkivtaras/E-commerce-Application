using Service_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.IServices
{
    public interface ICartService
    {
        CartServiceModel GetCartByCustomerId(int customerId);
        void AddCartItem(CartItemServiceModel cartItem);
        void UpdateCartItem(CartItemServiceModel cartItem);
        void RemoveCartItem(int id);
    }
}
