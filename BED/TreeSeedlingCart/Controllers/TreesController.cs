using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreeSeedlingCart.Interfaces;
using TreeSeedlingCart.Repositories;

namespace TreeSeedlingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreesController : ControllerBase
    {
        private readonly ITreesRepo _TreesRepo;
        public TreesController(ITreesRepo treesRepo)
        {
            _TreesRepo = treesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrees()
        {
            var trees = await _TreesRepo.GetAllTreesAsync();
            return Ok(trees);
        }
    }
}
