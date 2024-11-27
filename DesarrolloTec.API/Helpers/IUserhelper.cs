using Microsoft.AspNetCore.Identity;
using Veterinary.Shared.DTOs;
using Veterinary.Shared.Entities;

namespace DesarrolloTec.API.Helpers
{
    public interface IUserhelper
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginDTO model);

        Task LogoutAsync();



        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<User> GetUserAsync(Guid userId);



        // Implementación del método GetAllUsersAsync
        // Task<List<User>> GetAllUsersAsync();
        //Task<User> GetUserByIdAsync(string id); // Nuevo método
        //Task<IdentityResult> DeleteUserAsync(User user); // Nuevo métod
        //Task<IdentityResult> UpdateUserAsync(User user);
        //Task<IList<string>> GetRolesAsync(User user); // Nuevo método
        //Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles); // Nuevo método

    }
}
