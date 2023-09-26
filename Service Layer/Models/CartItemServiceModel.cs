
namespace Service_Layer.Models
{
    public class CartItemServiceModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
    }
}
