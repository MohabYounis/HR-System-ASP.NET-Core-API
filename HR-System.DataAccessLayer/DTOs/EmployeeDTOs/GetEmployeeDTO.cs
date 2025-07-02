using System.ComponentModel.DataAnnotations;

namespace HR_System.Core.DTOs.EmployeeDTOs
{
    public class GetEmployeeDTO
    {
        [Required]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "SSN must be 14 digits.")]
        public string SSN { get; set; }
        [Required]
        [MaxLength(100), MinLength(5)]
        public string FullName { get; set; }
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Invalid mobile number.")]
        public string Telephone { get; set; }
        public char Gender { get; set; }
        public string Nationality { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly ContractDate { get; set; }
        public decimal Salary { get; set; }
        public TimeOnly checkInTime { get; set; }
        public TimeOnly checkOutTime { get; set; }
        public bool IsDeleted { get; set; }
        public int? DepartmentNumber { get; set; }
        public string DepartmentName { get; set; }
    }
}
