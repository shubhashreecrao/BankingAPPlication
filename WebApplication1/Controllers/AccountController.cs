using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/accountdetails")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{accountNumber}")]
        public IActionResult GetAccountDetails(string accountNumber)
        {
            var account = _accountService.GetAccount(accountNumber);

            if (account == null)
                return NotFound("Account not found");

            return Ok(account);
        }
    }
}