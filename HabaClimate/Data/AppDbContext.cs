using HabaClimate.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HabaClimate.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AirConditioner> airConditioners { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Category> categories { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}