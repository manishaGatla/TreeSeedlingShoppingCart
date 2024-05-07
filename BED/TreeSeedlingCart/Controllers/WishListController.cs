using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreeSeedlingCart.Interfaces;
using TreeSeedlingCart.Models;
using TreeSeedlingCart.Repositories;

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

        [HttpGet]
        [Route("getWishListsByUserId")]
        public async Task<IActionResult> GetWishListsByUserId([FromQuery] int id)
        {
            var wishListDetails = await _wishListRepo.GetWishListsByUserIdAsync(id);
            return Ok(wishListDetails);
        }

        [HttpPost]
        public async Task<IActionResult> AddWishlistItems([FromBody] WishList item)
        {
            var addedCart = await _wishListRepo.AddWishListItems(item);
            return CreatedAtAction(nameof(AddWishlistItems), new { id = addedCart.Id }, addedCart);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWishListItem([FromQuery] int id)
        {
            await _wishListRepo.DeleteWishListItem(id);
            return Ok();
        }
    }
}
