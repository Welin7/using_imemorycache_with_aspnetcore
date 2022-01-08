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

        public Customer[] GetCacheCustomers()
        {
            Customer[] customers = null;
            if (!memoryCache.TryGetValue(KEY, out customers))
            {
                //can get data from database
                customers = new Customer[] {
                    new Customer { Id = 1, Name = "Claudio Faria", Cpf = "771.939.610-39" },
                    new Customer { Id = 2, Name = "Joao Guilherme Dias", Cpf = "081.597.690-91" },
                    new Customer { Id = 3, Name = "Patrick de Sousa", Cpf = "256.233.930-47" },
                    new Customer { Id = 4, Name = "Welington Dias", Cpf = "886.302.780-30" }
                };

                IncludeToCache(customers);
            }
            return customers;
        }
    }
}
