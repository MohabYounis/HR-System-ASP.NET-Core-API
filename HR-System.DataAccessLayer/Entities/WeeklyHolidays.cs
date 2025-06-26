using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Core.Entities
{
    [PrimaryKey(nameof(GId), nameof(Day))]
    [Index(nameof(Day), IsUnique = true)]
    public class WeeklyHolidays : BaseEntity
    {
        [ForeignKey(nameof(GeneralSetting))]
        public int GId { get; set; }
        [Required]

        public string Day { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual GeneralSetting GeneralSetting { get; set; }
    }
}
