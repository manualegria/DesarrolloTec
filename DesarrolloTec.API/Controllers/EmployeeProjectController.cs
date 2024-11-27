using DesarrolloTec.API.Data;
using DesarrolloTec.Shered.Entities;
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

        private readonly DataContext _context;
        public EmployeeProjectController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        //public async Task<IActionResult> Get()
        //{
        //    return Ok(await _context.EmployeeProjects.ToListAsync());
        //}

        public async Task<List<EmployeeProject>> GetInvoicesAsync()
        {
            return await _context.EmployeeProjects
                .Include(i => i.Projects)
                .Include(i => i.Employees)
                .ToListAsync();
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

                message = "creado con éxito.",
                message = "Empleado asignado a projecto.",
                data = employeeproject
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeProject employeeproject)
        {
            _context.EmployeeProjects.Update(employeeproject);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = " Actualizado con éxito.",

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

        public async Task<IActionResult> Delete(int id)
        {
            var Delete = await _context.EmployeeProjects
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (Delete == 0)
            {
                return NotFound(new { message = "Registro no encontrado." });

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

                return Ok(new { message = "Registro eliminado con éxito." });


            }
        }
    }
}
