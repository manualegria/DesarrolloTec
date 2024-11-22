using DesarrolloTec.API.Data;
using DesarrolloTec.Shared.Entities;
using DesarrolloTec.Shered.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloTec.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]
    [Route("/api/projects")]

    public class ProjectController : ControllerBase
    {
      
        private readonly DataContext _context;

        public ProjectController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        //public async  Task<IActionResult> Get()
        //{
        //    return Ok(await _context.Projects.ToListAsync());
        //}
        public async Task<List<Project>> GetInvoicesAsync()
        {
            return await _context.Projects
                .Include(i => i.Customers)
                .ToListAsync();
        }


        [HttpGet("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var project = await _context.Projects
            .Include(i => i.Customers)
            .SingleOrDefaultAsync(x => x.Id == id);

            if (project == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(project);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return Ok( new
            {
                message = "Proyecto creado con éxito.",
                data = project
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return Ok( project);
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var projectDelete = await _context.Projects.
                Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if(projectDelete == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { message = "Empleado eliminado con éxito.", data= projectDelete });
            }
        }
    }
}
