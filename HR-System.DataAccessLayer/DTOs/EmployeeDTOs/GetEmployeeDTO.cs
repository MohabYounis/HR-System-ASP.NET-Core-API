namespace HR_System.Core.DTOs.EmployeeDTOs
{
    public class GetEmployeeDTO : EmployeeDTO
    {
        public string SSN { get; set; }
        public bool IsDeleted { get; set; }
        public string DepartmentName { get; set; }
    }
}
