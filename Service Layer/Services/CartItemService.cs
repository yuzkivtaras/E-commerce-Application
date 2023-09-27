using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Service_Layer.IServices;
using Service_Layer.Models;

namespace Service_Layer.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CartItemService(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public CartItemServiceModel GetCartItemById(int id)
        {
            var cartItem = _cartItemRepository.GetById(id);
            return _mapper.Map<CartItemServiceModel>(cartItem);
        }

        public void AddCartItem(CartItemServiceModel cartItemServiceModel)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemServiceModel);
            _cartItemRepository.Add(cartItem);
        }

        public void UpdateCartItem(CartItemServiceModel cartItemServiceModel)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemServiceModel);
            _cartItemRepository.Update(cartItem);
        }

        public void RemoveCartItem(int id)
        {
            var cartItem = _cartItemRepository.GetById(id);
            _cartItemRepository.Remove(cartItem);
        }

        public IEnumerable<CartItemServiceModel> GetAllCartItems()
        {
            var cartItems = _cartItemRepository.GetAll();
            return _mapper.Map<IEnumerable<CartItemServiceModel>>(cartItems);
        }
    }
}