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

        [InverseProperty("Product")]
        public virtual ICollection<ProductNutrient> Nutrients { get; set; } = new List<ProductNutrient>();

        [InverseProperty("Product")]
        public virtual ICollection<UserProductConsumption> ConsumedByUsers { get; set; } = new List<UserProductConsumption>();
    }
}
