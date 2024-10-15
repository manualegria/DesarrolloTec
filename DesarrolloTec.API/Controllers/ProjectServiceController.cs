using DesarrolloTec.API.Data;
using DesarrolloTec.Shered.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;


namespace DesarrolloTec.API.Controllers
{
    public class ProjectServiceController : ControllerBase
    {

        private readonly DataContext _context;

        public ProjectServiceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _context.ProjectServices.ToListAsync());
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var projectservice = await _context.ProjectServices.SingleOrDefaultAsync(x => x.Id == id);

            if (projectservice == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(projectservice);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(ProjectService projectservice)
        {
            _context.ProjectServices.Add(projectservice);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Servicio integrado al proyecto creado con éxito.",
                data = projectservice
            });
        }

        [HttpPut]

        public async Task<IActionResult> Put(ProjectService projectservice)
        {
            _context.ProjectServices.Add(projectservice);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Servicio Actualizado al proyecto con éxito.",
                data = projectservice
            });
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var projectserviceDelete = await _context.ProjectServices.
                Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (projectserviceDelete == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { message = "Servicio del proyecto eliminado con éxito.", data = projectserviceDelete });
            }
        }
    }
}
