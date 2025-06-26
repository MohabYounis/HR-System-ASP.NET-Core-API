using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Core.Entities
{
    public class Employee : BaseEntity
    {
        [Key]
        public int SSN { get; set; }
        [Required]

        public string FName { get; set; }
        [Required]

        public string LName { get; set; }
        [Required]

        public string Telephone { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }
        public string Nationality { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly ContractDate { get; set; }
        public int Salary { get; set; }
        public TimeOnly checkInTime { get; set; }
        public TimeOnly checkOutTime { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey(nameof(AssignedDepartment))]
        public int? Dept_Num { get; set; }


        public virtual Department AssignedDepartment { get; set; }
        public virtual Department ManagedDepartment { get; set; }
        public virtual ICollection<Salary> Salaries { get; } = new List<Salary>();
        public virtual ICollection<AttendanceAndLeave> AttendanceAndLeaveRecordes { get; } = new List<AttendanceAndLeave>();
    }
}
