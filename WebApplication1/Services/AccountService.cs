using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class AccountService
    {
        private readonly IAccountDetailsRepository _repo;

        public AccountService(IAccountDetailsRepository repo)
        {
            _repo = repo; 
        }

        public Account GetAccount(string accountNumber)
        {
            return _repo.GetAccountByAccountNumber(accountNumber);
        }
    }
}