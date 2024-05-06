using Microsoft.EntityFrameworkCore;
using TreeSeedlingCart.Data;
using TreeSeedlingCart.Interfaces;
using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Repositories
{
    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDbContext _context;

        public CartRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CartItems>> GetCartItemsByUserIdAsync(int userId)
        {
            return await _context.CartItems.Where(u => u.UserId == userId).Include(c => c.Tree).ToListAsync();
        }

        public async Task<CartItems> AddCartItems(CartItems cart)
        {
            _context.CartItems.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task UpdateCartItem(CartItems cart)
        {
            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartItem(int id)
        {
            var cart = await _context.CartItems.FindAsync(id);
            if (cart != null)
            {
                _context.CartItems.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }
    }
}
