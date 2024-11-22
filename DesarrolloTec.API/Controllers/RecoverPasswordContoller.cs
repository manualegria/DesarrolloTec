//using DesarrolloTec.Shared.DTOs;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace DesarrolloTec.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class RecoverPasswordController : ControllerBase
//    {
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly IEmailService _emailService;

//        public RecoverPasswordController(UserManager<IdentityUser> userManager, IEmailService emailService)
//        {
//            _userManager = userManager;
//            _emailService = emailService;
//        }

//        [HttpPost("RecoverPassword")]
//        public async Task<IActionResult> RecoverPassword([FromBody] RecoverPasswordDTO recoverPasswordDTO)
//        {
//            var user = await _userManager.FindByEmailAsync(recoverPasswordDTO.Email);

//            if (user == null)
//            {
//                // Mensaje genérico por seguridad
//                return Ok("Si el correo ingresado está asociado a una cuenta, recibirás un enlace de recuperación.");
//            }

//            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
//            var resetLink = Url.Action("ResetPassword", "RecoverPassword",
//                new { token, email = recoverPasswordDTO.Email }, Request.Scheme);

//            // Simulación de envío de correo
//            await _emailService.SendAsync(
//                recoverPasswordDTO.Email,
//                "Recuperación de Contraseña",
//                $"Haz clic en este enlace para restablecer tu contraseña: {resetLink}"
//            );

//            return Ok("Si el correo ingresado está asociado a una cuenta, recibirás un enlace de recuperación.");
//        }

//        [HttpPost("ResetPassword")]
//        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
//        {
//            var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);

//            if (user == null)
//            {
//                return BadRequest("Solicitud inválida.");
//            }

//            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDTO.Token, resetPasswordDTO.NewPassword);

//            if (!result.Succeeded)
//            {
//                return BadRequest("El token es inválido o ha expirado.");
//            }

//            return Ok("La contraseña se ha restablecido correctamente.");
//        }
//    }
//}
