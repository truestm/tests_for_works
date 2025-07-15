using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom_test.Models
{
    [Table("ProductNutrients")]
    public class ProductNutrient
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Nutrient")]
        public int NutrientId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public virtual required Product Product { get; set; }
        public virtual required Nutrient Nutrient { get; set; }
    }
}
