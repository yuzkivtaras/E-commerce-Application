using Service_Layer.Models;

namespace Service_Layer.IServices
{
    public interface IProductService
    {
        IEnumerable<ProductServiceModel> GetAllProducts();
        ProductServiceModel GetProductById(int id);
        void AddProduct(ProductServiceModel product);
        void UpdateProduct(ProductServiceModel product);
        void RemoveProduct(int id);
    }
}
