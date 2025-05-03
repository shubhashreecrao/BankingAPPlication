using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IAccountDetailsRepository
    {
        Account GetAccountByAccountNumber(string accountNumber); // Contract for our data layer
    }
}