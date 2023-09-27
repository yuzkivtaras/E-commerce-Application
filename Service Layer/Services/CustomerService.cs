using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Service_Layer.IServices;
using Service_Layer.Models;

namespace Service_Layer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public IEnumerable<CustomerServiceModel> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            return _mapper.Map<IEnumerable<CustomerServiceModel>>(customers);
        }

        public CustomerServiceModel GetCustomerById(int id)
        {
            var customer = _customerRepository.GetById(id);
            return _mapper.Map<CustomerServiceModel>(customer);
        }

        public void AddCustomer(CustomerServiceModel customerServiceModel)
        {
            var customer = _mapper.Map<Customer>(customerServiceModel);
            _customerRepository.Add(customer);
        }

        public void UpdateCustomer(CustomerServiceModel customerServiceModel)
        {
            var customer = _mapper.Map<Customer>(customerServiceModel);
            _customerRepository.Update(customer);
        }

        public void RemoveCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);
            _customerRepository.Remove(customer);
        }
    }
}
