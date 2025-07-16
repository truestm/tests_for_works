using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiogenomAPI.Models
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

        [InverseProperty(nameof(Consumption.Product))]
        public virtual ICollection<Consumption> ConsumedByUsers { get; set; } = new List<Consumption>();
    }
}
