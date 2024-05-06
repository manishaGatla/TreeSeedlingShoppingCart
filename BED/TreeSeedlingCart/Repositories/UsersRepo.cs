
using Microsoft.EntityFrameworkCore;
using TreeSeedlingCart.Data;
using TreeSeedlingCart.Interfaces;
using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Repositories
{
    public class UsersRepo :IUsersRepo
    {
        private readonly ApplicationDbContext _context;

        public UsersRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Users> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == userName.ToLower());
        }

        public async Task<Users> AddUserAsync(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUserAsync(Users user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
