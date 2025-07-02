using HR_System.Core.DTOs.EmployeeDTOs;
using HR_System.Core.Entities;
using HR_System.Core.Helpers;
using HR_System.Core.Specifications.EmployeeSpecifications;

namespace HR_System.Core.Services.Contract
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Task<Pagination<GetEmployeeDTO>> GetPaginatedEmployeesWithSortingFilterationSearhing(EmployeeSpecParams specParams);
        Task<GetEmployeeDTO> GetEmployeeById(string ssn);
    }
}
