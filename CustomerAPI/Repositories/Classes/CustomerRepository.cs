using CustomerAPI.Models;
using CustomerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Repositories.Classes
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerAPIDbContext _dbContext;

        public CustomerRepository(CustomerAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddCustomer(Customer c)
        {
            try
            {
                if (c.State.Length > 2) // Assuming 'State' column can only hold 2 characters
                {
                    throw new Exception("State value is too long.");
                }
                await _dbContext.Customer.AddAsync(c);
                await _dbContext.SaveChangesAsync();
                return c;
            }
            catch (Exception e)
            {
                // Handle the exception as needed, such as logging or rethrowing
                throw new Exception("An error occurred while adding a customer.", e);
            }
        }

        public async Task<Customer> DeleteCustomer(Customer c)
        {
            try
            {
                _dbContext.Customer.Remove(c);
                await _dbContext.SaveChangesAsync();
                return c;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while deleting a customer.", e);
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                return await _dbContext.Customer.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting a customer by ID.", e);
            }
        }

        public async Task<List<Customer>> GetCustomers()
        {
            try
            {
                return await _dbContext.Customer.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting the list of customers.", e);
            }
        }

        public async Task<Customer> UpdateCustomer(Customer c)
        {
            try
            {
                var existingCustomer = await _dbContext.Customer.FirstOrDefaultAsync(customer => customer.Id == c.Id);

                if (existingCustomer != null)
                {
                    existingCustomer.Name = c.Name;
                    existingCustomer.Address = c.Address;
                    existingCustomer.CustomerTypeId = c.CustomerTypeId;
                    existingCustomer.Description = c.Description;
                    existingCustomer.City = c.City;
                    existingCustomer.State = c.State;
                    existingCustomer.Zip = c.Zip;
                    existingCustomer.LastUpdated = DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                    return existingCustomer;
                }
                else
                {
                    throw new Exception("Customer not found"); // Handle if the customer doesn't exist
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while updating a customer.", e);
            }
        }
    }
}
