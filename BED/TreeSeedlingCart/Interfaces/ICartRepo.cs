using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Interfaces
{
    public interface ICartRepo
    {
        Task<List<CartItems>> GetCartItemsByUserIdAsync(int userId);

        Task<CartItems> AddCartItems(CartItems cart);

        Task UpdateCartItem(CartItems cart);
        Task DeleteCartItem(int id);
    }
}
