using AutoMapper;
using DataAccessLayer.Entities;
using Service_Layer.Models;

namespace Service_Layer.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductServiceModel, Product>();
            CreateMap<Product, ProductServiceModel>();

            CreateMap<CustomerServiceModel, Customer>();
            CreateMap<Customer, CustomerServiceModel>();

            CreateMap<CategoryServiceModel, Category>();
            CreateMap<Category, CategoryServiceModel>();

            CreateMap<CartServiceModel, Cart>();
            CreateMap<Cart, CartServiceModel>();

            CreateMap<CartItemServiceModel, CartItem>();
            CreateMap<CartItem, CartItemServiceModel>();

            CreateMap<OrderServiceModel, Order>()
                .ForMember(dest => dest.Customer,
                           opt => opt.MapFrom(src => new Customer { Id = src.CustomerId, FullName = src.CustomerFullName }));
            CreateMap<Order, OrderServiceModel>()
                .ForMember(dest => dest.CustomerFullName, opt => opt.MapFrom(src => src.Customer.FullName));
        }
    }
}
