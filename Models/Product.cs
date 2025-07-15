using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom_test.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public required string Name { get; set; }

        [InverseProperty(nameof(ProductNutrient.Product))]
        public virtual ICollection<ProductNutrient> Nutrients { get; init; } = new List<ProductNutrient>();

        [InverseProperty(nameof(UserProductConsumption.Product))]
        public virtual ICollection<UserProductConsumption> ConsumedByUsers { get; set; } = new List<UserProductConsumption>();
    }
}
