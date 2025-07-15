using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom_test.Models
{
    [Table("ProductNutrients")]
    [PrimaryKey(nameof(ProductId), nameof(NutrientId))]
    public class ProductNutrient
    {
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [ForeignKey(nameof(Nutrient))]
        public int NutrientId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [InverseProperty(nameof(Product.Nutrients))]
        public virtual Product? Product { get; set; }

        [InverseProperty(nameof(Nutrient.ProductContents))]
        public virtual Nutrient? Nutrient { get; set; }
    }
}
