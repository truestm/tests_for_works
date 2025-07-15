using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom_test.Models
{
    [Table("UserProductConsumptions")]
    public class UserProductConsumption
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        public int TimesPerMonth { get; set; }

        [Required]
        public decimal TypicalPortionGrams { get; set; }

        public virtual required User User { get; set; }
        public virtual required Product Product { get; set; }
    }
}
