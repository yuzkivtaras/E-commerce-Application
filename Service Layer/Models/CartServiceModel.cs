
namespace Service_Layer.Models
{
    public class CartServiceModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<CartItemServiceModel> CartItems { get; set; }
    }
}
