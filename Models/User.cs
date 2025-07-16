using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom_test.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Lifestyle Lifestyle { get; set; }

        [InverseProperty(nameof(UserProductConsumption.User))]
        public virtual ICollection<UserProductConsumption> ProductConsumptions { get; set; } = new List<UserProductConsumption>();
    }
}
