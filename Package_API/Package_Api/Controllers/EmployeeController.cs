using Package_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Package_Api.Models;
using Package_Api.Utility;
using Microsoft.AspNetCore.Authorization;

namespace Package_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try { return await _context.Employees.ToListAsync(); }

            catch (Exception ex)
            {
                // Logging should be here as well
                return ResponseHelper.HandleDatabaseError(ex);
            }
        }

        // GET: api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound("No employee with this ID");
                }
                return Ok(employee);
            }

            catch (Exception ex)
            {
                // Logging should be here as well
                return ResponseHelper.HandleDatabaseError(ex);
            }
        }


        // POST: api/employee
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(string name)
        {
            try
            {
                Employee newEmployee = new Employee { Name = name };
                // Employee to context
                _context.Employees.Add(newEmployee);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetEmployee), new { id = newEmployee.Id }, newEmployee);
            }

            catch (Exception ex)
            {
                // Logging should be here as well
                return ResponseHelper.HandleDatabaseError(ex);
            }
        }
    }
}
