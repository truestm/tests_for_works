using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiogenomAPI.Models
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

        [InverseProperty(nameof(Consumption.User))]
        public virtual ICollection<Consumption> Consumptions { get; set; } = new List<Consumption>();
    }
}
