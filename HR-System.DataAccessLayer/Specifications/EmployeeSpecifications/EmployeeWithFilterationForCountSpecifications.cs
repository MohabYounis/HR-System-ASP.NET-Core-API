using HR_System.Core.Entities;

namespace HR_System.Core.Specifications.EmployeeSpecifications
{
    public class EmployeeWithFilterationForCountSpecifications : BaseSpecifications<Employee>
    {
        public EmployeeWithFilterationForCountSpecifications(EmployeeSpecParams specParams)
            : base(e =>
                        (string.IsNullOrEmpty(specParams.Search) || e.SSN.ToString().Contains(specParams.Search) ||
                        (e.FName + " " + e.LName).ToLower().Contains(specParams.Search))                         &&
                        (!specParams.DepartmentNum.HasValue || e.Dept_Num == specParams.DepartmentNum)           &&
                        (!specParams.Gender.HasValue || e.Gender == specParams.Gender)
            ) 
        { }
    }
}
