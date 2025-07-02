using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Core.Entities
{
    public class AttendanceAndLeave : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime AttendanceTime { get; set; } = DateTime.Now;
        public DateTime? LeaveTime { get; set; }
        [Column(TypeName = "date")]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [ForeignKey(nameof(Employee))]
        public string ESSN { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
