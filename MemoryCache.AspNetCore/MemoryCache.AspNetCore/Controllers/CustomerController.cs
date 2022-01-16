using MemoryCache.AspNetCore.Dto;
using MemoryCache.AspNetCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MemoryCache.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerCache customerCache;
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerCache _customerCache, ICustomerRepository _customerRepository)
        {
            this.customerCache = _customerCache;
            this.customerRepository = _customerRepository;
        }

        [HttpGet]
        public Customer[] Get()
        {
            return customerCache.GetCacheCustomers(customerRepository);
        }
       
        [HttpPost]
        public async Task<ActionResult<CustomerOutputPostDTO>> Post([FromBody] CustomerInputPostDTO inputDTO)
        {
            var customer = new Customer(inputDTO.Name, inputDTO.Cpf);
            await customerRepository.Save(customer);
            var outputDTO = new CustomerOutputPostDTO(customer.Id, customer.Name, customer.Cpf);
            return Ok(outputDTO);
        }
    }
}
