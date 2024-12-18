﻿using DesarrolloTec.API.Data;
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
    [Route("/api/projectServices")]
    public class ProjectServiceController : ControllerBase
    {

        private readonly DataContext _context;
        public ProjectServiceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        //public async Task<IActionResult> Get()
        //{
        //    return Ok(await _context.ProjectService.ToListAsync());
        //}

        public async Task<List<ProjectService>> GetInvoicesAsync()
        {
            return await _context.ProjectServices
                .Include(i => i.Projects)
                .Include(i => i.Services)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var projectservices = await _context.ProjectServices.SingleOrDefaultAsync(x => x.Id == id);

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
            _context.ProjectServices.Add(projectservices);
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
            _context.ProjectServices.Update(projectservices);
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
            var Delete = await _context.ProjectServices
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