using DesarrolloTec.API.Data;
using DesarrolloTec.Shered.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloTec.API.Controllers
{

    [ApiController]
    [Route("api/customers")]
    public class CustomerController:ControllerBase
    {
        private readonly DataContext _context;
        public CustomerController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get() 
        {
            return Ok(await _context.Customers.ToListAsync());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
            {

                return NotFound();
            }
            else
            {
                //   return Ok($"Customer {customer.Id}");
                 return Ok(customer);
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(Customer customer)
        {


            _context.Add(customer);


            await _context.SaveChangesAsync();

            return Ok(customer);

        }


        //Actualizar 
        [HttpPut]
        public async Task<ActionResult> Put(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);

        }


        // Eliminar 
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {

            var customerDelete = await _context.Customers
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (customerDelete == 0)
            {



                return NotFound(new { message = "Cliente no encontrado." });
            }
            else
            {

                return Ok(new { message = "Cliente eliminado con éxito." });
            }



        }



    }
}
