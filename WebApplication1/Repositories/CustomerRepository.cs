using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static List<Customer> customers = new()
        {
            new Customer { Id = 1, Name = "Ravi", AccountNumber = "123456", Balance = 25000 },
            new Customer { Id = 2, Name = "Divya", AccountNumber = "789101", Balance = 36000 }
        };

        public Customer GetCustomerByAccount(string accountNumber)
        {
            return customers.FirstOrDefault(c => c.AccountNumber == accountNumber);
        }
    }
}