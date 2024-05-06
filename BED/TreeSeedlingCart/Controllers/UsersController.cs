using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreeSeedlingCart.Interfaces;
using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo _usersRepository;

        public UsersController(IUsersRepo usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usersRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Users user)
        {
            var addedUser = await _usersRepository.AddUserAsync(user);
            return CreatedAtAction(nameof(AddUser), new { id = addedUser.Id }, addedUser);
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            var userDetails = await _usersRepository.GetUserByIdAsync(id);
            return Ok(userDetails);
        }

        [HttpGet]
        [Route("getByUserName")]
        public async Task<IActionResult> GetUserByUserName([FromQuery] string userName)
        {
            var userDetails = await _usersRepository.GetUserByUserNameAsync(userName);
            return Ok(userDetails);
        }
    }
}
