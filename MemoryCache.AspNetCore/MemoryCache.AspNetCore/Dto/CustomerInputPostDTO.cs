using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryCache.AspNetCore.Dto
{
    public class CustomerInputPostDTO
    {
        public string Name { get; set; }
        public string Cpf { get; set; }

        public CustomerInputPostDTO(string name, string cpf)
        {
            this.Name = name;
            this.Cpf = cpf; 
        }
    }
}
