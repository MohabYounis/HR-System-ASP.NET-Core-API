using HR_System.Core.Entities;

namespace HR_System.Core.Specifications.EmployeeSpecifications
{
    public class EmployeeWithDepartmentSpecifications : BaseSpecifications<Employee>
    {
        public EmployeeWithDepartmentSpecifications(EmployeeSpecParams specParams) 
            : base(e =>
                        (string.IsNullOrEmpty(specParams.Search)       || e.SSN.ToString().StartsWith(specParams.Search) ||
                         e.FullNameLower.StartsWith(specParams.Search))                                                  &&
                        (!specParams.DepartmentNum.HasValue            || e.Dept_Num == specParams.DepartmentNum)        &&
                        (!specParams.Gender.HasValue                   || e.Gender == specParams.Gender)                 &&
                        (specParams.AllEmployees                       || e.IsDeleted == specParams.AllEmployees)
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
                        AddOrderBy(e => e.FullNameLower);
                        break;
                }
            }
            else
            {
                AddOrderBy(e => e.FullNameLower);
            }

            AddPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
        }

        public EmployeeWithDepartmentSpecifications(string ssn) : base(e => e.SSN == ssn)
        {
            addIncludes();
        }

        private void addIncludes()
        {
            Includes.Add(e => e.AssignedDepartment);
        }
    }
}
