using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/balance")]
    public class BalanceController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public BalanceController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{accountNumber}")]
        public IActionResult GetBalance(string accountNumber)
        {
            var customer = _customerService.GetCustomer(accountNumber);

            if (customer == null)
                return NotFound("Customer not found");

            var dto = new CustomerDTO
            {
                Name = customer.Name,
                AccountNumber = customer.AccountNumber,
                Balance = customer.Balance
            };

            return Ok(dto);
        }
    }
}