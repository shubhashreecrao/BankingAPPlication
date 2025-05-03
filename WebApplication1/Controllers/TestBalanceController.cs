using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/testbalance")]
    public class TestBalanceController : ControllerBase
    {
        [HttpGet("{accountNumber}")]
        public IActionResult GetTestBalance(string accountNumber)
        {
            return Ok(new
            {
                accountNumber,
                balance = 12345,
                note = "This is a test endpoint"
            });
        }
    }
}
