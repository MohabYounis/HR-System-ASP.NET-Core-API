using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Core.Entities
{
    public class AnnualHolidays : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
