using CustomerAPI.Models;
using CustomerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Repositories.Classes
{
    public class CustomerTypeRepository : ICustomerTypeRepository
    {
        private readonly CustomerAPIDbContext _dbContext;
        public CustomerTypeRepository(CustomerAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CustomerType> AddCustomerType(CustomerType customerType)
        {
            try
            {
                await _dbContext.CustomerType.AddAsync(customerType);
                await _dbContext.SaveChangesAsync();
                return customerType;
            }
            catch (Exception e)
            {
                // Handle the exception as needed
                throw new Exception("An error occurred while adding a customer type.", e);
            }
        }

        public async Task<CustomerType> DeleteCustomerType(CustomerType customerType)
        {
            try
            {
                _dbContext.CustomerType.Remove(customerType);
                await _dbContext.SaveChangesAsync();
                return customerType;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while deleting a customer type.", e);
            }
        }

        public async Task<CustomerType> GetCustomerTypeById(int id)
        {
            try
            {
                return await _dbContext.CustomerType.FirstOrDefaultAsync(ct => ct.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting a customer type by ID.", e);
            }
        }

        public async Task<List<CustomerType>> GetCustomerTypes()
        {
            try
            {
                return await _dbContext.CustomerType.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting the list of customer types.", e);
            }
        }

        public async Task<CustomerType> UpdateCustomerType(CustomerType customerType)
        {
            try
            {
                var existingCustomerType = await _dbContext.CustomerType.FirstOrDefaultAsync(ct => ct.Id == customerType.Id);

                if (existingCustomerType != null)
                {
                    existingCustomerType.Name = customerType.Name;
                    await _dbContext.SaveChangesAsync();
                    return existingCustomerType;
                }
                else
                {
                    throw new Exception("Customer type not found");
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while updating a customer type.", e);
            }
        }
    }
}
