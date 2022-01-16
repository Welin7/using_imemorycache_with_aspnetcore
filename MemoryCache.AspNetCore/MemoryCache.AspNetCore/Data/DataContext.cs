using Microsoft.EntityFrameworkCore;

namespace MemoryCache.AspNetCore.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
