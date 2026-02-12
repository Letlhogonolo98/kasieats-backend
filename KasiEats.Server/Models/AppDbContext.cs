using Microsoft.EntityFrameworkCore;

namespace KasiEats.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // This creates the "FoodItems" table in the database
        public DbSet<FoodItem> FoodItems { get; set; }
    }
}