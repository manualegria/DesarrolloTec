using DesarrolloTec.API.Data;
using DesarrolloTec.Shared.Entities;
using DesarrolloTec.Shered.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace DesarrolloTec.API.Controllers
{
    public class TasksController : ControllerBase
    {
        private readonly DataContext _context;

        public TasksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Tasks.ToListAsync());
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var task = await _context.Tasks.SingleOrDefaultAsync(x => x.Id == id);

            if (task == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(task);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(Tasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Tarea creada con éxito.",
                data = task
            });
        }

        [HttpPut]

        public async Task<IActionResult> Put(Tasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Tarea Actualizada al proyecto con éxito.",
                data = task
            });
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var taskDelete = await _context.Tasks.
                Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (taskDelete == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { message = "Tarea eliminado con éxito.", data = taskDelete });
            }
        }
    }
}
