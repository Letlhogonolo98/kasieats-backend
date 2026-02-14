using KasiEats.Models;
using KasiEats.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace KasiEats.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }
}