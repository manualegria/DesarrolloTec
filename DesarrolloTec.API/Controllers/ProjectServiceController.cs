using DesarrolloTec.API.Data;
using DesarrolloTec.Shared.Entities;
using DesarrolloTec.Shered.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloTec.API.Controllers
{


    [ApiController]
    [Route("/api/projectServices")]
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
            return Ok(await _context.ProjectService.ToListAsync());
        }


        [HttpGet("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var projectservices = await _context.ProjectService.SingleOrDefaultAsync(x => x.Id == id);

            if (projectservices == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(projectservices);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(ProjectService projectservices)
        {
            _context.ProjectService.Add(projectservices);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "creado con éxito.",
                data = projectservices
            });
        }

        [HttpPut]

        public async Task<IActionResult> Put(ProjectService projectservices)
        {
            _context.ProjectService.Add(projectservices);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = " Actualizado con éxito.",
                data = projectservices
            });
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var Delete = await _context.ProjectService
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (Delete == 0)
            {
                return NotFound(new { message = "Registro no encontrado." });

            }
            else
            {
                return Ok(new { message = "Registro eliminado con éxito." });
            }
        }
    }
}
