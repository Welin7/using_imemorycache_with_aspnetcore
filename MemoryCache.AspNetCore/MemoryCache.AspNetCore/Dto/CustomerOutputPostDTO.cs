using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryCache.AspNetCore.Dto
{
    public class CustomerOutputPostDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }

        public CustomerOutputPostDTO(int id, string name, string cpf)
        {
            this.Id = id;
            this.Name = name;
            this.Cpf = cpf;
        }
    }
}
