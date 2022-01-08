using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryCache.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerCache customerCache;
        public CustomerController(ICustomerCache _customerCache)
        {
            this.customerCache = _customerCache;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerCache.GetCacheCustomers();
        }
    }
}
