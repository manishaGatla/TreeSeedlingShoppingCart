using Microsoft.EntityFrameworkCore;
using TreeSeedlingCart.Data;
using TreeSeedlingCart.Interfaces;
using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Repositories
{
    public class WishListRepo : IWishListRepo
    {
        private readonly ApplicationDbContext _context;

        public WishListRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WishList>> GetWishListsByIdAsync(int id)
        {
            return await _context.Wishlist.Where(u => u.Id == id).ToListAsync();
        }

        public async Task<List<WishList>> GetWishListsByUserIdAsync(int id)
        {
            return await _context.Wishlist.Where(u => u.UserId == id).Include(u => u.Tree).ToListAsync();
        }

        public async Task<WishList> AddWishListItems(WishList item)
        {
            _context.Wishlist.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteWishListItem(int id)
        {
            var item = await _context.Wishlist.FindAsync(id);
            if (item != null)
            {
                _context.Wishlist.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

    }
}
