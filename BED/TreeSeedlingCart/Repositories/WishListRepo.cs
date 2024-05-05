using TreeSeedlingCart.Data;
using TreeSeedlingCart.Interfaces;
using TreeSeedlingCart.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

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
            return await _context.Wishlists.Where(u => u.Id == id).ToListAsync();
        }

    }
}
