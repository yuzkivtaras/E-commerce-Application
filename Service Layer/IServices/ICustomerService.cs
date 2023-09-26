using Service_Layer.Models;

namespace Service_Layer.IServices
{
    public interface ICustomerService
    {
        IEnumerable<CustomerServiceModel> GetAllCustomers();
        CustomerServiceModel GetCustomerById(int id);
        void AddCustomer(CustomerServiceModel customer);
        void UpdateCustomer(CustomerServiceModel customer);
        void RemoveCustomer(int id);
    }
}
