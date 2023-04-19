using Microsoft.EntityFrameworkCore;
using OrderServices.Models;
using OrderServices.Models;

namespace OrderServices.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

    }
}