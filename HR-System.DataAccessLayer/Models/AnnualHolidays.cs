using System.ComponentModel.DataAnnotations;

namespace HR_System.DataAccessLayer.Models
{
    public class AnnualHolidays
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateOnly Date {  get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public bool IsDeleted { get; set; } = false;
    }
}
