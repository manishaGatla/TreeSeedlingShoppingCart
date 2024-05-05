using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Interfaces
{
    public interface IWishListRepo
    {
        Task<List<WishList>> GetWishListsByIdAsync(int id);
    }
}
