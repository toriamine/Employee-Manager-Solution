using EmployeeManager.Core.Services;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Core.Models;
using EmployeeManager.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee updated)
        {
            var existing = _employeeService.GetAllEmployees().FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return NotFound();

            existing.Name = updated.Name;
            existing.Age = updated.Age;
            existing.Department = updated.Department;

            _employeeService.UpdateEmployee(existing);  // добавим метод в сервис
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(Create), new { id = employee.Id }, employee);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetAllEmployees().FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();

            _employeeService.DeleteEmployee(employee);
            return NoContent();
        }

    }
}