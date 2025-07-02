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

        public async Task<Pagination<GetEmployeeDTO>> GetPaginatedEmployeesWithSortingFilterationSearhing(EmployeeSpecParams specParams)
        {
            var dataSpec = new EmployeeWithDepartmentSpecifications(specParams);
            var items = await GetAllWithSpecAsync(dataSpec) ?? [];

            var itemsDto = _mapper.Map<IReadOnlyList<GetEmployeeDTO>>(items);

            var countSpec = new EmployeeWithFilterationForCountSpecifications(specParams);
            var count = await GetCountAsync(countSpec);

            return new Pagination<GetEmployeeDTO>(specParams.PageIndex, specParams.PageSize, count, itemsDto);
        }

        public async Task<GetEmployeeDTO> GetEmployeeById(string ssn)
        {
            var spec = new EmployeeWithDepartmentSpecifications(ssn);
            var employee = await GetItemWithSpecAsync(spec);

            var employeeDto = _mapper.Map<GetEmployeeDTO>(employee);

            return employeeDto;
        }
    }
}
