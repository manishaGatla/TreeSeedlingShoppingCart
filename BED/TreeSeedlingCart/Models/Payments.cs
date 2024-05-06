namespace TreeSeedlingCart.Models
{
    public class Payments
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public string CardNumber { get; set; } 
        public int CVV { get; set; } 
        public string PaymentMethod { get; set; } 
        public string BillingAddress { get; set; } 
        public string CardHolderName { get; set; } 
        public string ExpiryDate { get; set; }
        public int? OrderId { get; set; } 


    }
}
