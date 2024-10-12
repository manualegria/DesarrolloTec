using DesarrolloTec.Shered.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesarrolloTec.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {

            _context = context;
        }

        public async Task SeedAsync()
        {
            // va a la base de datos y asegurese que sean los datos que le estoy enviando y guardelos
            await _context.Database.EnsureCreatedAsync();

            await CheckServiceAsync();
        }


        public async Task CheckServiceAsync()
        {
            if (!_context.Services.Any())
            {
                _context.Services.Add(new Service 
                { 
                    Name = "Asesoria",
                    Description = "Asesoria para almacenamiento en la nube",
                    EstimatedPrice = 500000


                });
             

            }
            await _context.SaveChangesAsync();

        }
    }
}
