using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreeSeedlingCart.Interfaces;

namespace TreeSeedlingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {

        private readonly IWishListRepo _wishListRepo;

        public WishListController(IWishListRepo wishListRepo)
        {
            _wishListRepo = wishListRepo;
        }


        [HttpGet]
        [Route("getWishListsById")]
        public async Task<IActionResult> GetWishListsById([FromQuery] int id)
        {
            var wishListDetails = await _wishListRepo.GetWishListsByIdAsync(id);
            return Ok(wishListDetails);
        }
    }
}
