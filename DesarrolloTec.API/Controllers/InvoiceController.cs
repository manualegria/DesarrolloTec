﻿using DesarrolloTec.API.Data;
using DesarrolloTec.Shared.Entities;
using DesarrolloTec.Shered.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloTec.API.Controllers
{

    [ApiController]
    [Route("/api/invoices")]
    public class InvoiceController : ControllerBase
    {

        private readonly DataContext _context;
        public InvoiceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Invoices.ToListAsync());
        }


        [HttpGet("{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var invoice = await _context.Invoices.SingleOrDefaultAsync(x => x.Id == id);

            if (invoice == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(invoice);
            }
        }
        [HttpPost]

        public async Task<IActionResult> Post(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Factura creada con éxito.",
                data = invoice
            });
        }

        [HttpPut]

        public async Task<IActionResult> Put(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Factura Actualizada con éxito.",
                data = invoice
            });
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var invoiceDelete = await _context.Invoices
                .Where(x => x.Id == id).ExecuteDeleteAsync();

            if (invoiceDelete == 0)
            {
                return NotFound(new { message = "Factura no encontrado." });

            }
            else
            {
                return Ok(new { message = "Factura eliminada con éxito." });
            }
        }
    }
}
