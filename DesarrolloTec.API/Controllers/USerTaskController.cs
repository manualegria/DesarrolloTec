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
        public async Task<List<USerTask>> GetInvoicesAsync()
        {
            var tasks = await _context.USerTasks
                .Include(t => t.Projects)
                .Include(t => t.Employees)
                .ToListAsync();

            return tasks; 
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
            var task = await _context.USerTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound(new { message = "Tarea no encontrada." });
            }

            _context.USerTasks.Remove(task);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Tarea eliminada con éxito." });
        }

    }
}


