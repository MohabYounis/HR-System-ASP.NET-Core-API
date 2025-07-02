using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Core.Entities
{
    public class Salary : BaseEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "money")]
        public decimal BasicSalary { get; set; }
        public int NumberOfAttendanceDays { get; set; }
        public int NumberOfAbsenceDays { get; set; }
        public int TotalAdditionalHours { get; set; }
        public int TotalDiscountHours { get; set; }
        [Column(TypeName = "money")]
        public decimal NetSalary { get; set; }
        [Column(TypeName = "date")]
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [ForeignKey(nameof(Employee))]
        public string ESSN { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
