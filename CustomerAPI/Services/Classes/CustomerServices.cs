using CustomerAPI.Models;
using CustomerAPI.Repositories.Interfaces;
using CustomerAPI.Services.Interfaces;

namespace CustomerAPI.Services.Classes
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _repo;
        public CustomerServices(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public async Task<Customer> AddCustomer(Customer c)
        {
            return await _repo.AddCustomer(c);
        }

        public async Task<Customer> DeleteCustomer(Customer c)
        {
            return await _repo.DeleteCustomer(c);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _repo.GetCustomerById(id);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _repo.GetCustomers();
        }

        public async Task<Customer> UpdateCustomer(Customer c)
        {
            return await _repo.UpdateCustomer(c);
        }
    }
}
