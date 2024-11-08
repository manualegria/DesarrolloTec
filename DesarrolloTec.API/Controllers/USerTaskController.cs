using DesarrolloTec.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesarrolloTec.Shared.Entities;

namespace DesarrolloTec.API.Controllers
{

    [ApiController]
    [Route("/api/task")]
    public class USerTasksController : ControllerBase
    {

        private readonly DataContext _context;

        public USerTasksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.USerTasks.ToArrayAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var USerTask = await _context.USerTasks.FirstOrDefaultAsync(x => x.Id == id);

            if (USerTask == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(USerTask);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(USerTask task)
        {
            _context.USerTasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Tarea creada con éxito.",
                data = task
            });
        }

        [HttpPut]

        public async Task<ActionResult> Put(USerTask task)
        {
            _context.USerTasks.Update(task);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Tarea actualizada con éxito.",
                data = task
            });

        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var delete = await _context.USerTasks
                .Where(x => x.Id == id)
            .ExecuteDeleteAsync();

            if (delete == 0)
            {
                return NotFound(new { message = "Tarea no encontrada." });

            }
            else
            {
                return Ok(new { message = "Tarea eliminada con éxito." });
            }
        }
    }
}


