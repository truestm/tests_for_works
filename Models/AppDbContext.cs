using Microsoft.EntityFrameworkCore;

namespace Biogenom_test.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<ProductNutrient> ProductNutrients { get; set; }
        public DbSet<UserProductConsumption> UserProductConsumptions { get; set; }
        public DbSet<NutritionalNorm> NutritionalNorms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
