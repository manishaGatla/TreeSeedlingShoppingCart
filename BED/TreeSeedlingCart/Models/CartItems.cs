namespace TreeSeedlingCart.Models
{
    public class CartItems
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TreeId { get; set; }
        public int Quantity { get; set; }
    }
}
