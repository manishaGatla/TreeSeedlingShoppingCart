using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreeSeedlingCart.Interfaces;
using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepo _cartRepo;

        public CartController(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }

        [HttpGet]
        [Route("getCartItemsByUserId")]
        public async Task<IActionResult> GetCartItemsByUserId([FromQuery] int userId)
        {
            var userCartDetails = await _cartRepo.GetCartItemsByUserIdAsync(userId);
            return Ok(userCartDetails);
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItems([FromBody] CartItems cart)
        {
            var addedCart = await _cartRepo.AddCartItems(cart);
            return CreatedAtAction(nameof(AddCartItems), new { id = addedCart.Id }, addedCart);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartItem([FromBody] CartItems cart)
        {
            await _cartRepo.UpdateCartItem(cart);
            return Ok(cart);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCartItem([FromQuery] int id)
        {
            await _cartRepo.DeleteCartItem(id);
            return Ok();
        }
    }
}
