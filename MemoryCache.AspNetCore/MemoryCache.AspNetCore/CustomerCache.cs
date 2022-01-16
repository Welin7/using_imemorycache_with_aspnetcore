using MemoryCache.AspNetCore.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;


namespace MemoryCache.AspNetCore
{
    public class CustomerCache : ICustomerCache
    {
        private const string KEY = "customer_cache";
        private readonly IMemoryCache memoryCache;
        public CustomerCache(IMemoryCache _memoryCache)
        {
            this.memoryCache = _memoryCache;
        }

        public void IncludeToCache(Customer[] customers)
        {
            var option = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(60),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(120),

            };

            memoryCache.Set<Customer[]>(KEY, customers, option);
        }

        public Customer[] GetCacheCustomers(ICustomerRepository customerRepository)
        {
            Customer[] customers = null;
            if (!memoryCache.TryGetValue(KEY, out customers))
            {
                //can get data from database
                customers = customerRepository.GetAllCustomers();
                IncludeToCache(customers);
            }
            return customers;
        }
    }
}
