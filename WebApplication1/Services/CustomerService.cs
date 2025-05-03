using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;  // Inject repository
        }

        public Customer GetCustomer(string accountNumber)
        {
            return _repo.GetCustomerByAccount(accountNumber);
        }
    }
}