using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Models
{
    public class CustomerAPIDbContext : DbContext {
        public CustomerAPIDbContext(DbContextOptions options):base(options) { }
        public DbSet<Customer> Customer { get; set;}
        public DbSet<CustomerType> CustomerType { get; set;}
    }
    
}
