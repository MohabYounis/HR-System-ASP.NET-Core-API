using HR_System.Core.Entities;
using HR_System.Core.Services.Contract;
using HR_System.Core.Specifications.EmployeeSpecifications;
using HR_System.Presentation.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBaseService<Employee> _employeeService;
        public EmployeeController(IBaseService<Employee> employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet("Active")]
        public async Task<ActionResult> GetActiveEmployees()
        {
            var employees = await _employeeService.GetExistAsync();
            return Ok(employees);
        }


        [HttpGet]
        public async Task<ActionResult> GetAllEmployees([FromQuery] EmployeeSpecParams specParams)
        {
            var dataSpec = new EmployeeWithDepartmentSpecifications(specParams);
            var items = await _employeeService.GetAllWithSpecAsync(dataSpec);

            var countSpec = new EmployeeWithFilterationForCountSpecifications(specParams); 
            var count = await _employeeService.GetCountAsync(countSpec);

            return Ok(GeneralResponse.Success(new Pagination<Employee>(specParams.PageIndex, specParams.PageSize, count, items), "Success"));
        }


        [HttpGet("{ssn:int}")]
        public async Task<ActionResult> GetEmployee(int ssn)
        {
            var spec = new EmployeeWithDepartmentSpecifications(ssn);

            var employee = await _employeeService.GetItemWithSpecAsync(spec);
            if (employee == null)
                return NotFound();   

            return Ok(employee);    
        }

    }
}
