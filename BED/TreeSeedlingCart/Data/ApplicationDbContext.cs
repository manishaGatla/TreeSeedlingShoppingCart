using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using TreeSeedlingCart.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TreeSeedlingCart.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public Microsoft.EntityFrameworkCore.DbSet<Users> Users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Trees> Trees { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<CartItems> CartItems { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ShippingAddresses> ShippingAddresses { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Orders> Orders { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<WishList> Wishlist { get; set; }

      
    }
}
