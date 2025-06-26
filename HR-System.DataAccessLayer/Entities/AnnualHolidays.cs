using System.ComponentModel.DataAnnotations;

namespace HR_System.Core.Entities
{
    public class AnnualHolidays : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public bool IsDeleted { get; set; } = false;
    }
}
