//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DesarrolloTec.Shared.DTOs
//{
//    public class ResetPasswordDTO
//    {
//        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
//        [EmailAddress(ErrorMessage = "Debes ingresar un correo válido.")]
//        public string Email { get; set; } = null!;

//        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
//        public string Token { get; set; } = null!;

//        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
//        [StringLength(20, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre {2} y {1} caracteres.")]
//        [DataType(DataType.Password)]
//        public string NewPassword { get; set; } = null!;

//        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
//        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden.")]
//        [DataType(DataType.Password)]
//        public string ConfirmPassword { get; set; } = null!;
//    }
//}
