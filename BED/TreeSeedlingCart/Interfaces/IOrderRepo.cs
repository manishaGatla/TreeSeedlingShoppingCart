using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Interfaces
{
    public interface IOrderRepo
    {
        void CreateOrderAndPayment(int UserId, Payments payment, ShippingAddresses addresses, List<TreeDetail> trees);

        Task<List<OrderViewModel>> GetOrdersByUserId(int userId);
    }
}
