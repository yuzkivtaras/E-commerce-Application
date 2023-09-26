using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Service_Layer.IServices;
using Service_Layer.Models;

namespace Service_Layer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductServiceModel> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductServiceModel>>(products);
        }

        public ProductServiceModel GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductServiceModel>(product);
        }

        public void AddProduct(ProductServiceModel productServiceModel)
        {
            var product = _mapper.Map<Product>(productServiceModel);
            _productRepository.Add(product);
        }

        public void UpdateProduct(ProductServiceModel productServiceModel)
        {
            var product = _mapper.Map<Product>(productServiceModel);
            _productRepository.Update(product);
        }

        public void RemoveProduct(int id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Remove(product);
        }
    }
}
