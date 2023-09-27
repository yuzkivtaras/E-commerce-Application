using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.IServices;
using Service_Layer.Models;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICartItemService _cartItemService;
        private readonly ICartService _cartService;

        public ShoppingCartController(IProductService productService, ICartItemService cartItemService, ICartService cartService)
        {
            _productService = productService;
            _cartItemService = cartItemService;
            _cartService = cartService;
        }

        [HttpGet("products")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("cart/{userId}")]
        public IActionResult GetCartItems(int userId)
        {
            var cartItems = _cartService.GetCartByCustomerId(userId).CartItems;
            return Ok(cartItems);
        }

        [HttpPost("cart/{cartId}/add")]
        public IActionResult AddCartItem(int cartId, [FromBody] CartItemServiceModel cartItemServiceModel)
        {
            cartItemServiceModel.CartId = cartId;
            _cartItemService.AddCartItem(cartItemServiceModel);
            return Ok("Item added to cart");
        }

        [HttpPut("cart/update")]
        public IActionResult UpdateCartItem([FromBody] CartItemServiceModel cartItemServiceModel)
        {
            _cartItemService.UpdateCartItem(cartItemServiceModel);
            return Ok("Item updated in the cart");
        }

        [HttpDelete("cart/remove/{cartItemId}")]
        public IActionResult RemoveCartItem(int cartItemId)
        {
            _cartItemService.RemoveCartItem(cartItemId);
            return Ok("Cart item removed");
        }
    }
}
