using MemoryCache.AspNetCore.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryCache.AspNetCore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task <Customer> Save(Customer customer)
        {
           _dataContext.Customers.Add(customer);
           await _dataContext.SaveChangesAsync();
           return customer;
        }
       
        public Customer[] GetAllCustomers()
        {
            return _dataContext.Customers.ToArray();
        }      
    }
}
