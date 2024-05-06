namespace TreeSeedlingCart.Models
{
    public class OrderEntity
    {
        public int UserId { get; set; }
        public Payments payments { get; set; }
        public ShippingAddresses addresses { get; set; }

        public List<TreeDetail> Trees { get; set; }
    }

    public class TreeDetail
    {
        public int TreeId { get; set; }
        public int Quantity { get; set; }
    }
}
