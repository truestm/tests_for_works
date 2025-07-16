using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom_test.Models
{
    [Table("Consumptions")]
    [PrimaryKey(nameof(UserId), nameof(ProductId))]
    public class Consumption
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Required]
        public int TimesPerMonth { get; set; }

        [Required]
        public decimal TypicalPortionGrams { get; set; }

        [InverseProperty(nameof(User.Consumptions))]
        public virtual User? User { get; set; }

        [InverseProperty(nameof(Product.ConsumedByUsers))]
        public virtual Product? Product { get; set; }
    }
}
