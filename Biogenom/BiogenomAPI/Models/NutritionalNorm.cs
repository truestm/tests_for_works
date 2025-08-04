using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiogenomAPI.Models
{
    [Table("NutritionalNorms")]
    public class NutritionalNorm
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Nutrient))]
        public int NutrientId { get; set; }

        public Gender? Gender { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        [Required]
        public Lifestyle? Lifestyle { get; set; }

        public decimal? DailyNorm { get; set; }
        public decimal? DailyNormWeight { get; set; }
        
        public string? Description { get; set; }

        [InverseProperty(nameof(Nutrient.Norms))]
        public virtual Nutrient? Nutrient { get; set; }
    }
}
