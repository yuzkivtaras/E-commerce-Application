using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Service_Layer.IServices;
using Service_Layer.Models;

namespace Service_Layer.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public CartServiceModel GetCartByCustomerId(int customerId)
        {
            var cart = _cartRepository.GetCartByCustomerId(customerId);
            return _mapper.Map<CartServiceModel>(cart);
        }

        public void AddCartItem(CartItemServiceModel cartItemServiceModel)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemServiceModel);
            _cartRepository.AddItemToCart(cartItem);
        }

        public void UpdateCartItem(CartItemServiceModel cartItemServiceModel)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemServiceModel);
            _cartRepository.UpdateCartItem(cartItem);
        }

        public void RemoveCartItem(int id)
        {
            var cartItem = _cartRepository.GetItemById(id);
            _cartRepository.RemoveCartItem(cartItem);
        }
    }
}
