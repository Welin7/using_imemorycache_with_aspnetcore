using MemoryCache.AspNetCore.Repositories;

namespace MemoryCache.AspNetCore
{
    public interface ICustomerCache
    {
        Customer[] GetCacheCustomers(ICustomerRepository customerRepositor);
        void IncludeToCache(Customer[] customers);
    }
}