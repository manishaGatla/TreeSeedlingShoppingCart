using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Interfaces
{
    public interface ITreesRepo
    {
        Task<List<Trees>> GetAllTreesAsync();
    }
}
