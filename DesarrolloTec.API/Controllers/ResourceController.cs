﻿using DesarrolloTec.API.Data;
using DesarrolloTec.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloTec.API.Controllers
{
    [ApiController]
    [Route("/api/resources")]
    public class ResourceController : ControllerBase
    {
        private readonly DataContext _context;
        public ResourceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Resourcess.ToListAsync());
        }


        [HttpGet("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var resource = await _context.Resourcess.SingleOrDefaultAsync(x => x.Id == id);

            if (resource == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(resource);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(Resource resource)
        {
            _context.Resourcess.Add(resource);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Recurso creado con éxito.",
                data = resource
            });
        }

        [HttpPut]

        public async Task<IActionResult> Put(Resource resource)
        {
            _context.Resourcess.Add(resource);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Recurso Actualizado con éxito.",
                data = resource
            });
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var resourceDelete = await _context.Resourcess
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (resourceDelete == 0)
            {
                return NotFound(new { message = "Recurso no encontrado." });

            }
            else
            {
                return Ok(new { message = "Recurso eliminado con éxito." });
            }
        }
    }
}