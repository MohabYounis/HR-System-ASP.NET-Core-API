using HR_System.Core.Entities;

namespace HR_System.Core.Specifications.EmployeeSpecifications
{
    public class EmployeeWithDepartmentSpecifications : BaseSpecifications<Employee>
    {
        public EmployeeWithDepartmentSpecifications(EmployeeSpecParams specParams) 
            : base(e =>
                        (string.IsNullOrEmpty(specParams.Search)       || e.SSN.ToString().Contains(specParams.Search) ||
                        (e.FName + " " + e.LName).ToLower().Contains(specParams.Search))                               &&
                        (!specParams.DepartmentNum.HasValue            || e.Dept_Num == specParams.DepartmentNum)      &&
                        (!specParams.Gender.HasValue                   || e.Gender == specParams.Gender)
            )
        {
            addIncludes();

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "salaryAsc":
                        AddOrderBy(e => e.Salary);
                        break;
                    case "salaryDesc":
                        AddOrderByDesc(e => e.Salary);
                        break;
                    default:
                        AddOrderBy(e => e.FName);
                        break;
                }
            }
            else
            {
                AddOrderBy(e => e.FName);
            }

            AddPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
        }

        public EmployeeWithDepartmentSpecifications(int ssn) : base(e => e.SSN == ssn)
        {
            addIncludes();
        }

        private void addIncludes()
        {
            Includes.Add(e => e.AssignedDepartment);
            Includes.Add(e => e.ManagedDepartment);
        }
    }
}
