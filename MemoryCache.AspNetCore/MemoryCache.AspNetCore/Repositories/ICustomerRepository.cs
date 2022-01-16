using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemoryCache.AspNetCore.Repositories
{
    public interface ICustomerRepository
    {
        Task <Customer> Save(Customer customer);
        Customer[] GetAllCustomers();
    }
}