using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Veterinary.Shared.DTOs;
using Veterinary.Shared.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DesarrolloTec.API.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Veterinary.API.Controllers
{
    

    [ApiController]
    [Route("/api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IUserhelper _userHelper;
        private readonly IConfiguration _configuration;

        public AccountsController(IUserhelper userHelper, IConfiguration configuration)
        {
            _userHelper = userHelper;
            _configuration = configuration;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] UserDTO model)
        {
            User user = model;
            var result = await _userHelper.AddUserAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userHelper.AddUserToRoleAsync(user, user.UserType.ToString());
                return Ok(BuildToken(user));
            }

            return BadRequest(result.Errors.FirstOrDefault());
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                // Llama al método de UserHelper para obtener todos los usuarios
                var users = await _userHelper.GetAllUsersAsync();

                // Si se obtienen usuarios, se retornan con un estado 200 OK
                if (users != null && users.Count > 0)
                {
                    return Ok(users);
                }

                // Si no hay usuarios, retornamos un estado 404
                return NotFound("No se encontraron usuarios.");
            }
            catch (Exception ex)
            {
                // En caso de un error, retornamos un error 500
                return StatusCode(500, $"Error al obtener los usuarios: {ex.Message}");
            }
        }
    

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO model)
        {
            var result = await _userHelper.LoginAsync(model);
            if (result.Succeeded)
            {
                var user = await _userHelper.GetUserAsync(model.Email);
                return Ok(BuildToken(user));
            }

            return BadRequest("Email o contraseña incorrectos.");
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userHelper.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            var result = await _userHelper.DeleteUserAsync(user);
            if (result.Succeeded)
            {
                return Ok("Usuario eliminado correctamente.");
            }

            return BadRequest("No se pudo eliminar el usuario.");
        }

        [HttpPut("EditUser/{id}")]
        public async Task<IActionResult> EditUser(string id, [FromBody] UserDTO model)
        {
            var user = await _userHelper.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Document = model.Document;
            user.Photo = model.Photo;
            user.UserType = model.UserType;

            var result = await _userHelper.UpdateUserAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest("No se pudo actualizar el usuario.");
            }

            var currentRoles = await _userHelper.GetRolesAsync(user);
            if (!currentRoles.Contains(user.UserType.ToString()))
            {
                await _userHelper.RemoveFromRolesAsync(user, currentRoles);
                await _userHelper.AddUserToRoleAsync(user, user.UserType.ToString());
            }

            return Ok("Usuario actualizado correctamente.");
        }

        //[HttpPut("EditUser/{id}")]
        //public async Task<IActionResult> EditUser(string id, [FromBody] UserDTO model)
        //{
        //    var user = await _userHelper.GetUserByIdAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound("Usuario no encontrado.");
        //    }

        //    user.FirstName = model.FirstName;
        //    user.LastName = model.LastName;
        //    user.Document = model.Document;
        //    user.Photo = model.Photo;
        //    user.UserType = model.UserType;

        //    var result = await _userHelper.UpdateUserAsync(user);
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest("No se pudo actualizar el usuario.");
        //    }

        //    var currentRoles = await _userHelper.GetRolesAsync(user);
        //    var newRole = user.UserType.ToString();

        //    if (!currentRoles.Contains(newRole))
        //    {
        //        var removeResult = await _userHelper.RemoveFromRolesAsync(user, currentRoles);
        //        if (!removeResult.Succeeded)
        //        {
        //            return BadRequest("No se pudieron eliminar los roles antiguos del usuario.");
        //        }

        //        var addResult = await _userHelper.AddUserToRoleAsync(user, newRole);
        //        if (!addResult.Succeeded)
        //        {
        //            return BadRequest("No se pudo asignar el nuevo rol al usuario.");
        //        }
        //    }

        //    return Ok("Usuario actualizado correctamente.");
        //}

        private TokenDTO BuildToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email!),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
                new Claim("Document", user.Document),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("Photo", user.Photo ?? string.Empty),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtKey"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(30);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            return new TokenDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}