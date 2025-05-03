namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id { get; set; }                  // Unique customer ID
        public string Name { get; set; }             // Customer name
        public string AccountNumber { get; set; }    // Account number
        public double Balance { get; set; }          // Account balance
    }
}