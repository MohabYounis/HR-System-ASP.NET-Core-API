using System.ComponentModel.DataAnnotations;

namespace HR_System.Core.DTOs.EmployeeDTOs
{
    public abstract class EmployeeDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string FullName { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$", ErrorMessage = "Phone must be a valid Egyptian mobile number.")]
        public string Telephone { get; set; }
        [Required]
        public char Gender { get; set; }
        public string Nationality { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly ContractDate { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be positive.")]
        public decimal Salary { get; set; }
        public TimeOnly checkInTime { get; set; }
        public TimeOnly checkOutTime { get; set; }
        public int? DepartmentNumber { get; set; }
    }
}
