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
<<<<<<< HEAD
    [Route("/api/projectServices")]

using DesarrolloTec.Shered.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;


namespace DesarrolloTec.API.Controllers
{

=======
    [Route("api/projectServices")]
>>>>>>> emirDev
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
        //public async Task<IActionResult> Get()
        //{
        //    return Ok(await _context.ProjectService.ToListAsync());
        //}

        public async Task<List<ProjectService>> GetInvoicesAsync()
        {
            return await _context.ProjectService
                .Include(i => i.Projects)
                .Include(i => i.Services)
                .ToListAsync();
        }

            return Ok(await _context.ProjectServices.ToListAsync());
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
        public async Task<IActionResult> Post(ProjectService projectservices)
        {
            _context.ProjectService.Add(projectservices);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "creado con éxito.",
                data = projectservices

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

        public async Task<IActionResult> Put(ProjectService projectservices)
        {
            _context.ProjectService.Update(projectservices);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = " Actualizado con éxito.",
                data = projectservices

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

            var Delete = await _context.ProjectService
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (Delete == 0)
            {
                return NotFound(new { message = "Registro no encontrado." });

            }
            else
            {
                return Ok(new { message = "Registro eliminado con éxito." });

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
