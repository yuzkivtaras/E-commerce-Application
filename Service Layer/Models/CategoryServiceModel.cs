
namespace Service_Layer.Models
{
    public class CategoryServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ProductServiceModel> Products { get; set; }
    }
}
