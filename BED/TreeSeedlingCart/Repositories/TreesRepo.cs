using Microsoft.EntityFrameworkCore;
using TreeSeedlingCart.Data;
using TreeSeedlingCart.Interfaces;
using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Repositories
{
    public class TreesRepo : ITreesRepo
    {
        private readonly ApplicationDbContext _context;

        public TreesRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Trees>> GetAllTreesAsync()
        {
            return await _context.Trees.ToListAsync();
        }

    }
}
