using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Core.Entities
{
    [Index(nameof(FullNameLower))]
    public class Employee : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string SSN { get; set; }
        private string _fullName;
        [Required]
        public string FullName 
        {
            get 
            { 
                return _fullName; 
            }
            set 
            {
                _fullName = value;
                FullNameLower = value?.ToLower();
            } 
        }
        public string FullNameLower { get; private set; }
        [Required]
        public string Telephone { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }
        public string Nationality { get; set; }
        [Column(TypeName = "date")]
        public DateOnly DateOfBirth { get; set; }
        [Column(TypeName = "date")]
        public DateOnly ContractDate { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly checkInTime { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly checkOutTime { get; set; }
        [ForeignKey(nameof(AssignedDepartment))]
        public int? Dept_Num { get; set; }


        public virtual Department AssignedDepartment { get; set; }
        public virtual Department ManagedDepartment { get; set; }
        public virtual ICollection<Salary> Salaries { get; } = new List<Salary>();
        public virtual ICollection<AttendanceAndLeave> AttendanceAndLeaveRecordes { get; } = new List<AttendanceAndLeave>();
    }
}
