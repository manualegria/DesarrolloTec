using DesarrolloTec.API.Data;
using DesarrolloTec.Shered.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace DesarrolloTec.API.Controllers
{

    [ApiController]
    [Route("/api/employeeprojectcontroller")]

    public class EmployeeProjectController : ControllerBase
    {

        private readonly DataContext _context;
        public EmployeeProjectController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _context.EmployeeProjects.ToListAsync());
        }


        [HttpGet("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var employeeproject = await _context.EmployeeProjects.SingleOrDefaultAsync(x => x.Id == id);

            if (employeeproject == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(employeeproject);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(EmployeeProject employeeproject)
        {
            _context.EmployeeProjects.Add(employeeproject);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Empleado asignado a projecto.",
                data = employeeproject
            });
        }

        [HttpPut]
        //Actulizar
        public async Task<IActionResult> Put(EmployeeProject employeeproject)
        {
            _context.EmployeeProjects.Add(employeeproject);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Empleado Actualizado en proyecto.",
                data = employeeproject
            });
        }

        [HttpDelete("{id:int}")]
        //Eliminar
        public async Task<IActionResult> Delete(int id)
        {
            var employeeprojectDelete = await _context.EmployeeProjects
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (employeeprojectDelete == 0)
            {
                return NotFound(new { message = "Empleado no encontrado en el proyecto." });

            }
            else
            {
                return Ok(new { message = "Empleado eliminado del projecto con éxito." });
            }
        }
    }
}
