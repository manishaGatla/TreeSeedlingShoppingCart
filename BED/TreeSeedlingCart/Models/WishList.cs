namespace TreeSeedlingCart.Models
{
    public class WishList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TreeId { get; set; }

        public virtual Trees? Tree { get; set; }
    }
}
