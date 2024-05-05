namespace TreeSeedlingCart.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TreeId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int AddressId { get; set; }
    }
}
