
namespace Service_Layer.Models
{
    public class OrderServiceModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
