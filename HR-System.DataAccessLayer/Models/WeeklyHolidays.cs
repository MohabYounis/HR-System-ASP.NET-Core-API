using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.DataAccessLayer.Models
{
    [PrimaryKey(nameof(GId), nameof(Day))]
    [Index(nameof(Day), IsUnique = true)]
    public class WeeklyHolidays
    {
        [ForeignKey(nameof(GeneralSetting))]
        public int GId { get; set; }
        [Required]

        public string Day {  get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual GeneralSetting GeneralSetting { get; set; }
    }
}
