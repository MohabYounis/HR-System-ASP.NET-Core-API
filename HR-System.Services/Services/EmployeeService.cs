using AutoMapper;
using HR_System.Core.DTOs.EmployeeDTOs;
using HR_System.Core.Entities;
using HR_System.Core.Helpers;
using HR_System.Core.Services.Contract;
using HR_System.Core.Specifications.EmployeeSpecifications;
using HR_System.Core.UnitsOfWork.Contract;

namespace HR_System.Services.Services
{
    public class EmployeeService : BaseService<Employee>,IEmployeeService
    {
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }


        public async Task<GeneralResponse> GetPaginatedEmployeesWithSortingFilterationSearhing(EmployeeSpecParams specParams)
        {
            var dataSpec = new EmployeeWithDepartmentSpecifications(specParams);
            var items = await GetAllWithSpecAsync(dataSpec) ?? [];

            var itemsDto = _mapper.Map<IReadOnlyList<GetEmployeeDTO>>(items);

            var countSpec = new EmployeeWithFilterationForCountSpecifications(specParams);
            var count = await GetCountAsync(countSpec);

            if (count == 0)
                return GeneralResponse.Failure("No employees exist.");

            return GeneralResponse.Success("Employees retrieved successfully.", new Pagination<GetEmployeeDTO>(specParams.PageIndex, specParams.PageSize, count, itemsDto));
        }


        public async Task<GeneralResponse> GetEmployeeById(string ssn)
        {
            var spec = new EmployeeWithDepartmentSpecifications(ssn);
            var employee = await GetItemWithSpecAsync(spec);

            if (employee is null)
                return GeneralResponse.Failure("No employee exist.");

            var employeeDto = _mapper.Map<GetEmployeeDTO>(employee);

            return GeneralResponse.Success("Employee retrieved successfully.", employeeDto);
        }


        public async Task<GeneralResponse> AddEmployeeIfNoExist(CreateEmployeeDTO employeeFromReq)   
        {
            var spec = new EmployeeWithDepartmentSpecifications(employeeFromReq.SSN, employeeFromReq.Telephone);
            var existEmployee = await GetItemWithSpecAsync(spec);

            if (existEmployee is not null)
                return GeneralResponse.Failure("Telephone or SSN is already existed.");
            
            var employee = _mapper.Map<Employee>(employeeFromReq);
            await AddAsync(employee);
            await SaveInDBAsync();

            var employeeDto = _mapper.Map<GetEmployeeDTO>(employee);

            return GeneralResponse.Success("New employee has been added successfully.", employeeDto);
        }


        public async Task<GeneralResponse> EditEmployeeIfExist(string ssn, EditEmployeeDTO employeeFromReq)
        {
            var spec = new EmployeeWithDepartmentSpecifications(ssn);
            var existEmployee = await GetItemWithSpecAsync(spec);

            if (existEmployee is null)
                return GeneralResponse.Failure("No employees exist.");

            var telSpec = new EmployeeWithDepartmentSpecifications(null, employeeFromReq.Telephone);
            var employeeWithTelephone = await GetItemWithSpecAsync(telSpec);

            if (employeeWithTelephone is not null && employeeWithTelephone.SSN != existEmployee.SSN)
                return GeneralResponse.Failure("Telephone is already used by another employee.");

            _mapper.Map(employeeFromReq, existEmployee);
            Update(existEmployee);
            await SaveInDBAsync();

            return GeneralResponse.Success("Employee has been edited successfully.", employeeFromReq);
        }


        public async Task<GeneralResponse> DeleteEmployeeIfExist(string ssn)
        {
            var spec = new EmployeeWithDepartmentSpecifications(ssn);
            var employee = await GetItemWithSpecAsync(spec);

            if (employee is null)
                return GeneralResponse.Failure("No employee exist.");

            if (employee.IsDeleted == true)
                return GeneralResponse.Failure("Employee is already deleted.");

            await DeleteAsync(employee);
            await SaveInDBAsync();

            return GeneralResponse.Success("Employee deleted successfully.");
        }
    }
}
