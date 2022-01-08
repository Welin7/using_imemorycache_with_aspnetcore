namespace MemoryCache.AspNetCore
{
    public interface ICustomerCache
    {
        Customer[] GetCacheCustomers();
        void IncludeToCache(Customer[] customers);
    }
}