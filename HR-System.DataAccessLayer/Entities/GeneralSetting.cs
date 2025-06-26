using System.ComponentModel.DataAnnotations;

namespace HR_System.Core.Entities
{
    public class GeneralSetting : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int AdditionalHours { get; set; }
        public int DiscountHours { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<WeeklyHolidays> GeneralSettings { get; } = new List<WeeklyHolidays>();
    }
}
