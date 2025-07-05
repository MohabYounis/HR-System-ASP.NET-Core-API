using HR_System.Core.DTOs.EmployeeDTOs;
using HR_System.Core.Helpers;
using HR_System.Core.Services.Contract;
using HR_System.Core.Specifications.EmployeeSpecifications;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    // Primary Constructor C#12
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;

        // Get Employees
        [HttpGet]
        [EndpointDescription("GET uri/api/employee - Returns a paginated collection of employee records. Supports filtering by parameters,"
                             + " keyword searching, and sorting by specific fields.")]
        [EndpointSummary("Retrieve a paginated list of employees with optional filtering, searching, and sorting.")]
        [ProducesResponseType(200, Type = typeof(Pagination<GetEmployeeDTO>))]
        [ProducesResponseType(404, Type = typeof(GeneralResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<ActionResult> GetAllEmployees([FromQuery] EmployeeSpecParams specParams)
        {
            try
            {
                var paginatedItems = await _employeeService.GetPaginatedEmployeesWithSortingFilterationSearhing(specParams);

                if (!paginatedItems.IsSuccess)
                    return NotFound(paginatedItems.Message);

                return Ok(paginatedItems);
            }
            catch
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }


        // Get Employee
        [HttpGet("{ssn}")]
        [EndpointDescription("GET api/employee/{ssn} - Retrieves an employee by SSN.")]
        [EndpointSummary("Get a single employee by SSN.")]
        [ProducesResponseType(200, Type = typeof(GetEmployeeDTO))]
        [ProducesResponseType(404, Type = typeof(GeneralResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<ActionResult> GetEmployee(string ssn)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(ssn);

                if (!employee.IsSuccess)
                    return NotFound(employee.Error);

                return Ok(employee);
            }
            catch
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }


        // Add Employee
        [HttpPost]
        [EndpointDescription("POST api/employee - Creates a new employee.")]
        [EndpointSummary("Add a new employee.")]
        [ProducesResponseType(201, Type = typeof(CreateEmployeeDTO))]
        [ProducesResponseType(400, Type = typeof(GeneralResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<ActionResult> AddEmployee(CreateEmployeeDTO employeeFromReq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var employee = await _employeeService.AddEmployeeIfNoExist(employeeFromReq);

                if (!employee.IsSuccess)
                    return BadRequest(employee.Error);

                return CreatedAtAction(nameof(GetEmployee),
                                        new { employee.Data?.SSN },
                                        new { employee.Data?.SSN, employee.Data?.FullName, employee.Data?.DepartmentNumber }
                                       );
            }
            catch
            {
                return StatusCode(500, "An unexpected error occurred.");
            } 
        }


        // Edit Employee
        [HttpPut("{ssn}")]
        [EndpointDescription("PUT api/employee/{ssn} - Updates an existing employee by SSN.")]
        [EndpointSummary("Edit an existing employee.")]
        [ProducesResponseType(200, Type = typeof(EditEmployeeDTO))]
        [ProducesResponseType(400, Type = typeof(GeneralResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<ActionResult> EditEmployeeIfExist(string ssn, EditEmployeeDTO employeeFromReq)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var employee = await _employeeService.EditEmployeeIfExist(ssn, employeeFromReq);

                if (!employee.IsSuccess)
                    return BadRequest(employee.Error);

                return Ok(employee);
            }
            catch
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }


        // Delete Employee
        [HttpDelete("{ssn}")]
        [EndpointDescription("DELETE api/employee/{ssn} - Deletes an existing employee by SSN.")]
        [EndpointSummary("Delete an employee.")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(GeneralResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<ActionResult> DeleteEmployeeIfExist(string ssn)
        {
            try
            {
                var deleteEmployee = await _employeeService.DeleteEmployeeIfExist(ssn);
                
                if (!deleteEmployee.IsSuccess)
                    return BadRequest(deleteEmployee.Error);

                return Ok(deleteEmployee.Message);
            }
            catch
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
