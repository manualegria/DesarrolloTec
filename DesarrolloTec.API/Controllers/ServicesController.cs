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
     [Route("/api/services")]

     public class ServiceController : ControllerBase
     {
            private readonly DataContext _context;

            public ServiceController(DataContext context)
            {
                _context = context;
            }

        [AllowAnonymous]
            [HttpGet]
            public async Task<ActionResult> Get()
            {
              return Ok(await _context.Services.ToArrayAsync());
            }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var Services = await _context.Services.FirstOrDefaultAsync( x => x.Id == id);

            if (Services == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Services);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Servicio creado con éxito.",
                data = service
            });
        }

        [HttpPut]

        public async Task<ActionResult> Put(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Servicio actualizado con éxito.",
                data = service
            });

        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id )
        {
            var delete = await _context.Services
                .Where( x => x.Id == id )
            .ExecuteDeleteAsync();

            if(delete == 0)
            {
                return NotFound(new { message = "Servicio no encontrado." });

            }
            else
            {
                return Ok(new { message = "Servicio eliminado con éxito." });
            }
        }
     }
   
    
}
