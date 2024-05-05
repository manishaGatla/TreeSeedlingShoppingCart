using System.Collections.Generic;
using System.Threading.Tasks;
using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Interfaces
{
    public interface IUsersRepo
    {
        Task<List<Users>> GetAllUsersAsync();
        Task<Users> GetUserByIdAsync(int id);
        Task<Users> AddUserAsync(Users user);
        Task UpdateUserAsync(Users user);
        Task DeleteUserAsync(int id);
    }
}



