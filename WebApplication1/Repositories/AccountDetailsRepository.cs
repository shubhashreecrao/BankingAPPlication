using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class AccountDetailsRepository : IAccountDetailsRepository
    {
        private static List<Account> accountDetails = new()
        {
            new Account {AccountNumber="12345", Status = "Active", AccountType = "Savings", AccountNominee = "xsd",AccountOpeningDate = new DateTime(2023, 9, 12) },
           new Account  { AccountNumber="12365",Status = "Active", AccountType = "Savings", AccountNominee = "ijk", AccountOpeningDate = new DateTime(2023, 9, 12) },
        };

        public  Account GetAccountByAccountNumber(string accountNumber)
        {
            return accountDetails.FirstOrDefault(c => c.AccountNumber == accountNumber);
        }
    }
}