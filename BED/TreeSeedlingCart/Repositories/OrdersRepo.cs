using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TreeSeedlingCart.Data;
using TreeSeedlingCart.Interfaces;
using TreeSeedlingCart.Models;

namespace TreeSeedlingCart.Repositories
{
    public class OrdersRepo :IOrderRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly string connectionString = "Server=LAPTOP-GU8QAIGJ;Database=TreeSeedlingShoppingCart;Trusted_Connection=True;";

        public OrdersRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateOrderAndPayment(int UserId, Payments payment, ShippingAddresses addresses, List<TreeDetail> trees)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("sp_CreateOrderPaymentAndAddress", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserId);
                command.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                command.Parameters.AddWithValue("@CardNumber", payment.CardNumber);
                command.Parameters.AddWithValue("@CVV", payment.CVV);
                command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                command.Parameters.AddWithValue("@BillingAddress", payment.BillingAddress);
                command.Parameters.AddWithValue("@CardHolderName", payment.CardHolderName);
                command.Parameters.AddWithValue("@ExpiryDate", payment.ExpiryDate);
                command.Parameters.AddWithValue("@Address1", addresses.Address1);
                command.Parameters.AddWithValue("@Address2", addresses.Address2 ?? (object)DBNull.Value);  
                command.Parameters.AddWithValue("@City", addresses.City);
                command.Parameters.AddWithValue("@State", addresses.State);
                command.Parameters.AddWithValue("@PostalCode", addresses.PostalCode);
                command.Parameters.AddWithValue("@Country", addresses.Country);
                DataTable treeOrders = new DataTable();
                treeOrders.Columns.Add("TreeId", typeof(int));
                treeOrders.Columns.Add("Quantity", typeof(int));

                foreach (var tree in trees)
                {
                    treeOrders.Rows.Add(tree.TreeId, tree.Quantity);
                }

                // Add the parameter when calling the stored procedure
                command.Parameters.AddWithValue("@TreeOrders", treeOrders);
                command.Parameters["@TreeOrders"].SqlDbType = SqlDbType.Structured;
                command.Parameters["@TreeOrders"].TypeName = "TreeOrderType";
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public async Task<List<OrderViewModel>> GetOrdersByUserId(int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetOrdersByUserId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserID", userId));

                    var results = new List<OrderViewModel>();
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var orderId = reader.GetInt32(reader.GetOrdinal("OrderId"));
                            var order = results.FirstOrDefault(o => o.Id == orderId);
                            if (order == null)
                            {
                                order = new OrderViewModel
                                {
                                    Id = orderId,
                                    Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                    Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                                    Items = new List<OrderItemViewModel>(),
                                    Address = new ShippingAddresses
                                    {
                                        Address1 = reader["Address1"].ToString(),
                                        Address2 = reader["Address2"].ToString(),
                                        City = reader["City"].ToString(),
                                        State = reader["State"].ToString(),
                                        PostalCode = reader["PostalCode"].ToString(),
                                        Country = reader["Country"].ToString(),
                                    },
                                };
                                results.Add(order);
                            }

                            order.Items.Add(new OrderItemViewModel
                            {
                                TreeId = reader.GetInt32(reader.GetOrdinal("TreeId")),
                                Description = reader.GetString(reader.GetOrdinal("TreeDescription")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"))
                            });
                        }
                    }

                    return results;
                }
            }
        }

    }
}
