using CustomerAPI.Models;
using CustomerAPI.Repositories.Interfaces;
using CustomerAPI.Services.Interfaces;

namespace CustomerAPI.Services.Classes
{
    public class CustomerTypeServices : ICustomerTypeServices
    {
        private readonly ICustomerTypeRepository _repo;
        public CustomerTypeServices(ICustomerTypeRepository repo)
        {
            _repo = repo;
        }

        public async Task<CustomerType> AddCustomerType(CustomerType customerType)
        {
           return await _repo.AddCustomerType(customerType);
        }

        public async Task<CustomerType> DeleteCustomerType(CustomerType customerType)
        {
            return await _repo.DeleteCustomerType(customerType);
        }

        public async Task<CustomerType> GetCustomerTypeById(int id)
        {
            return await _repo.GetCustomerTypeById(id);
        }

        public async Task<List<CustomerType>> GetCustomerTypes()
        {
            return await _repo.GetCustomerTypes();
        }

        public async Task<CustomerType> UpdateCustomerType(CustomerType customerType)
        {
            return await _repo.UpdateCustomerType(customerType);
        }
    }
}
