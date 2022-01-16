
namespace MemoryCache.AspNetCore
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }

        public Customer(string name, string cpf)
        {
            this.Name = name;
            this.Cpf = cpf;
        }
    }
}
