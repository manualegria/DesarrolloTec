using DesarrolloTec.API.Data;
using DesarrolloTec.Shared.Entities;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloTec.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]
    [Route("/api/resources")]
    public class ResourceController : ControllerBase
    {
        private readonly DataContext _context;
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace DesarrolloTec.API.Controllers
{
    public class ResourceController : ControllerBase
    {
        private readonly DataContext _context;

>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a
        public ResourceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

<<<<<<< HEAD
        public async Task<List<Resource>> GetInvoicesAsync()
        {
            return await _context.Resourcess
                .Include(i => i.Projects)
                .ToListAsync();
        }


=======
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Resourcess.ToListAsync());
        }

>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a
        [HttpGet("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
<<<<<<< HEAD
            var resource = await _context.Resourcess
            .Include(i => i.Projects)
            .SingleOrDefaultAsync(x => x.Id == id);
=======
            var resource = await _context.Resourcess.SingleOrDefaultAsync(x => x.Id == id);
>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a

            if (resource == null)
            {
                return NotFound();
<<<<<<< HEAD

=======
>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a
            }
            else
            {
                return Ok(resource);
            }
        }
<<<<<<< HEAD
          
=======

>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a
        [HttpPost]

        public async Task<IActionResult> Post(Resource resource)
        {
            _context.Resourcess.Add(resource);
            await _context.SaveChangesAsync();
<<<<<<< HEAD
            return Ok(new
            {
                message = "Recurso creado con éxito.",
=======

            return Ok(new
            {
                message = "Recurso creado con exito.",
>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a
                data = resource
            });
        }

        [HttpPut]

        public async Task<IActionResult> Put(Resource resource)
        {
<<<<<<< HEAD
            _context.Resourcess.Update(resource);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Recurso Actualizado con éxito.",
=======
            _context.Resourcess.Add(resource);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Recurso Actualizado al proyecto con éxito.",
>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a
                data = resource
            });
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
<<<<<<< HEAD
            var resourceDelete = await _context.Resourcess
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (resourceDelete == 0)
            {
                return NotFound(new { message = "Recurso no encontrado." });

            }
            else
            {
                return Ok(new { message = "Recurso eliminado con éxito." });
=======
            var resourceDelete = await _context.Resourcess.
                Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (resourceDelete == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { message = "Recurso eliminado con éxito.", data = resourceDelete });
>>>>>>> 63af2a287ed4823e7cd5c959bd1201c1c6c8e90a
            }
        }
    }
}
