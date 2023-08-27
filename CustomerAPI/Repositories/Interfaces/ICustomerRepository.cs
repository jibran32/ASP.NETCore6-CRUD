using CustomerAPI.Models;

namespace CustomerAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> AddCustomer(Customer c);
        Task<Customer> UpdateCustomer(Customer c);
        Task<Customer> DeleteCustomer(Customer c);
        Task<Customer> GetCustomerById(int id);
    }
}
