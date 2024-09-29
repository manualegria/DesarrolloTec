using DesarrolloTec.API.Data;
using DesarrolloTec.Shered.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace DesarrolloTec.API.Controllers
{

    [ApiController]
    [Route("/api/employee")]

    public class EmployeeController : ControllerBase
    {

        private readonly DataContext _context;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Employees.ToListAsync());
        }


        [HttpGet("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(employee);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Empleado creado con éxito.",
                data = employee
            }); 
        }

        [HttpPut]

        public async Task<IActionResult> Put(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Empleado Actualizado con éxito.",
                data = employee
            });
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var employeeDelete = await _context.Employees
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (employeeDelete == 0)
            {
                return NotFound(new { message = "Empleado no encontrado." });

            }
            else
            {
                return Ok(new { message = "Empleado eliminado con éxito." });
            }
        }
    }
}
