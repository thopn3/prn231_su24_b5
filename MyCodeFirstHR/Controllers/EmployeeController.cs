using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCodeFirstHR.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCodeFirstHR.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly HRContext _context;
        public EmployeeController(HRContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> List()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Details(long id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound("The Employee record couldn't found");

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee not empty");
            employee.EmployeeId = 0;

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Details), new { Id = employee.EmployeeId }, employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(long id, [FromForm]Employee newEmployee)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound("The Employee record couldn't found");

            if (newEmployee == null)
                return BadRequest("Employee not empty");

            // Update values -> Properties
            employee.FirstName = newEmployee.FirstName;
            employee.LastName = newEmployee.LastName;
            employee.DateOfBirth = newEmployee.DateOfBirth;
            employee.Email = newEmployee.Email;
            employee.PhoneNumber = newEmployee.PhoneNumber;
            employee.Gender = newEmployee.Gender;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound("The Employee record couldn't found");

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

