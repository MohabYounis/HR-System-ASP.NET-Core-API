using HR_System.DataAccessLayer.HelpingClasses;
using HR_System.DataAccessLayer.Models;
using HR_System.Services.Services;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            var employee = await _employeeService.GetItemAsyncWithExpression(criteria: e => e.Salary > 9000);
            var employeeDTO = new
            {
                Id = employee.SSN,
                FullName = employee.FName + " " + employee.LName,
                Salary = employee.Salary,
            };
            return Ok(employeeDTO);
        }
    }
}
