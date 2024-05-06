using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreeSeedlingCart.Data;
using TreeSeedlingCart.Interfaces;
using TreeSeedlingCart.Models;
using TreeSeedlingCart.Repositories;

namespace TreeSeedlingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _orderRepo;

        public OrdersController(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        [Route("getOrdersByUserId")]
        public async Task<IActionResult> GetOrdersByUserId([FromQuery] int userId)
        {
            var orderDetails = await _orderRepo.GetOrdersByUserId(userId);
            return Ok(orderDetails);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderEntity orderEntity)
        {
             _orderRepo.CreateOrderAndPayment(orderEntity.UserId, orderEntity.payments, orderEntity.addresses, orderEntity.Trees);
            return Ok();
        }
    }
}
