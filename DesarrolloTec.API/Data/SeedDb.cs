using DesarrolloTec.API.Helpers;
using DesarrolloTec.Shared.Enums;
using DesarrolloTec.Shered.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Veterinary.Shared.Entities;

namespace DesarrolloTec.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        private readonly IUserhelper _userHelper;
        public SeedDb(DataContext context, IUserhelper userHelper)
        {

            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            // va a la base de datos y asegurese que sean los datos que le estoy enviando y guardelos
            await _context.Database.EnsureCreatedAsync();

            await CheckServiceAsync();

            await CheckRolesAsync();

            await CheckUserAsync("123", "Emir","Alegria", "Emir@correo.com", "3228866", UserType.Admin);


            //await _context.SaveChangesAsync();
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }


        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {

                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,

                    PhoneNumber = phone,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

            }

            return user;
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
