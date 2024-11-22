using DesarrolloTec.API.Data;
using DesarrolloTec.Shered.Entities;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloTec.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/api/employeeProject")]
    public class EmployeeProjectController : ControllerBase
    {


=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace DesarrolloTec.API.Controllers
{

    [ApiController]
    [Route("/api/employeeprojectcontroller")]

    public class EmployeeProjectController : ControllerBase
    {

>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a
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
<<<<<<< HEAD
                message = "creado con éxito.",
=======
                message = "Empleado asignado a projecto.",
>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a
                data = employeeproject
            });
        }

        [HttpPut]
<<<<<<< HEAD

        public async Task<IActionResult> Put(EmployeeProject employeeproject)
        {
            _context.EmployeeProjects.Update(employeeproject);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = " Actualizado con éxito.",
=======
        //Actulizar
        public async Task<IActionResult> Put(EmployeeProject employeeproject)
        {
            _context.EmployeeProjects.Add(employeeproject);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Empleado Actualizado en proyecto.",
>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a
                data = employeeproject
            });
        }

        [HttpDelete("{id:int}")]
<<<<<<< HEAD

        public async Task<IActionResult> Delete(int id)
        {
            var Delete = await _context.EmployeeProjects
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (Delete == 0)
            {
                return NotFound(new { message = "Registro no encontrado." });
=======
        //Eliminar
        public async Task<IActionResult> Delete(int id)
        {
            var employeeprojectDelete = await _context.EmployeeProjects
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (employeeprojectDelete == 0)
            {
                return NotFound(new { message = "Empleado no encontrado en el proyecto." });
>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a

            }
            else
            {
<<<<<<< HEAD
                return Ok(new { message = "Registro eliminado con éxito." });
=======
                return Ok(new { message = "Empleado eliminado del projecto con éxito." });
>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a
            }
        }
    }
}
