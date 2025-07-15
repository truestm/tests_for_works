using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        [InverseProperty(nameof(ProductNutrient.Nutrient))]
        public virtual ICollection<ProductNutrient> ProductContents { get; set; } = new List<ProductNutrient>();

        [JsonIgnore]
        [InverseProperty(nameof(NutritionalNorm.Nutrient))]
        public virtual ICollection<NutritionalNorm> Norms { get; set; } = new List<NutritionalNorm>();

    }
}
