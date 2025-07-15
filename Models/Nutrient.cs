using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom_test.Models
{
    [Table("Nutrients")]
    public class Nutrient
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        public required NutrientUnit Unit { get; set; } = NutrientUnit.Gram;

        [InverseProperty("Nutrient")]
        public virtual ICollection<ProductNutrient> ProductContents { get; set; } = new List<ProductNutrient>();

        [InverseProperty("Nutrient")]
        public virtual ICollection<NutritionalNorm> Norms { get; set; } = new List<NutritionalNorm>();
    }
}
