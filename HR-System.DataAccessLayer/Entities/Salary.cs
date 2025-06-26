using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Core.Entities
{
    public class Salary : BaseEntity
    {
        public int Id { get; set; }
        public int BasicSalary { get; set; }
        public int NumberOfAttendanceDays { get; set; }
        public int NumberOfAbsenceDays { get; set; }
        public int TotalAdditionalHours { get; set; }
        public int TotalDiscountHours { get; set; }
        public int NetSalary { get; set; }
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public bool IsDeleted { get; set; } = false;
        [ForeignKey(nameof(Employee))]
        public int? ESSN { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
