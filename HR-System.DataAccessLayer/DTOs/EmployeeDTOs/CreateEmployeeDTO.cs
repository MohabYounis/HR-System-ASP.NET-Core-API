using System.ComponentModel.DataAnnotations;

namespace HR_System.Core.DTOs.EmployeeDTOs
{
    public class CreateEmployeeDTO : EmployeeDTO
    {
        [Required]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "SSN must be 14 digits.")]
        public string SSN { get; set; }
    }
}
