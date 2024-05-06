namespace TreeSeedlingCart.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int AddressId { get; set; }

        public virtual Users? User { get; set; }

        public virtual ShippingAddresses? ShippingAddresses { get; set; }
    }

    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TreeId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
        public ShippingAddresses Address { get; set; } 
        public OrderViewModel()
        {
            Items = new List<OrderItemViewModel>();  // Ensure the list is initialized
        }
    }

    public class OrderItemViewModel
    {
        public int TreeId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }


}
