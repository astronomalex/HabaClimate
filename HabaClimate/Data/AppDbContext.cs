using HabaClimate.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HabaClimate.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AirConditioner> AirConditioners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}