using CustomerAPI.Models;

namespace CustomerAPI.Services.Interfaces
{
    public interface ICustomerServices
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> AddCustomer(Customer c);
        Task<Customer> UpdateCustomer(Customer c);
        Task<Customer> DeleteCustomer(Customer c);
        Task<Customer> GetCustomerById(int id);

    }
}
