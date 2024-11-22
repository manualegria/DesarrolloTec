using DesarrolloTec.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Veterinary.Shared.DTOs;
using Veterinary.Shared.Entities;

namespace DesarrolloTec.API.Helpers
{
    public class UserHelper : IUserhelper
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {


            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;


        }


        //Crear un nuevo usuario
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }


        public async Task<SignInResult> LoginAsync(LoginDTO model)
        {

            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

        }

        public async Task LogoutAsync()
        {

            await _signInManager.SignOutAsync();

        }

        // Implementación del método GetAllUsersAsync
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();  // Obtiene todos los usuarios desde la base de datos
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles)
        {
            return await _userManager.RemoveFromRolesAsync(user, roles);
        }
    }
}
