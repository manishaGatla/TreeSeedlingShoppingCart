using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Interfaces
{
    public interface IWishListRepo
    {
        Task<List<WishList>> GetWishListsByIdAsync(int id);
        Task<WishList> AddWishListItems(WishList item);
        Task<List<WishList>> GetWishListsByUserIdAsync(int id);
        Task DeleteWishListItem(int id);
    }
}
