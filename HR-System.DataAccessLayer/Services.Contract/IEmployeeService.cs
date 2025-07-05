using HR_System.Core.DTOs.EmployeeDTOs;
using HR_System.Core.Entities;
using HR_System.Core.Helpers;
using HR_System.Core.Specifications.EmployeeSpecifications;

namespace HR_System.Core.Services.Contract
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Task<GeneralResponse> GetPaginatedEmployeesWithSortingFilterationSearhing(EmployeeSpecParams specParams);
        Task<GeneralResponse> GetEmployeeById(string ssn);
        Task<GeneralResponse> AddEmployeeIfNoExist(CreateEmployeeDTO employee);
        Task<GeneralResponse> EditEmployeeIfExist(string ssn, EditEmployeeDTO employeeFromReq);
        Task<GeneralResponse> DeleteEmployeeIfExist(string ssn);
    }
}
