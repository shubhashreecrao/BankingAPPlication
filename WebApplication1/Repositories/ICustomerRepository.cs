using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerByAccount(string accountNumber); // Contract for our data layer
    }
}