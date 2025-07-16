using BiogenomAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BiogenomAPI
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<ProductNutrient> ProductNutrients { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<NutritionalNorm> NutritionalNorms { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
