using HR_System.Core.Services.Contract;
using HR_System.Core.Specifications.EmployeeSpecifications;
using HR_System.Presentation.Generals;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Get Employees
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees([FromQuery] EmployeeSpecParams specParams)
        {
            try
            {
                var paginatedItems = await _employeeService.GetPaginatedEmployeesWithSortingFilterationSearhing(specParams);

                if (!paginatedItems.Items.Any())
                    return NotFound(GeneralResponse.Failure("No employees found."));

                return Ok(GeneralResponse.Success(paginatedItems, "Employees retrieved successfully."));
            }
            catch(Exception ex)
            {
                return StatusCode(500, GeneralResponse.Failure(ex.Message));
            }
        }


        // Get Employee
        [HttpGet("{ssn:alpha}")]
        public async Task<ActionResult> GetEmployee(string ssn)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(ssn);

                if (employee == null)
                    return NotFound(GeneralResponse.Failure("No employees found."));

                return Ok(GeneralResponse.Success(employee, "Employees retrieved successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, GeneralResponse.Failure(ex.Message));
            }
        }


        // Add Employee
        //[HttpPost]
        //public async Task<ActionResult> AddEmployee()
        //{

        //}
    }
}
