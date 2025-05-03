namespace WebApplication1.DTOs
{
    public class CustomerDTO
    {
        public string Name { get; set; }             // We only want to expose Name
        public string AccountNumber { get; set; }    // And account number
        public double Balance { get; set; }          // And current balance
    }
}