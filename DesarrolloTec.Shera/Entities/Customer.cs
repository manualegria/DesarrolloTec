using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloTec.Shered.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del cliente")]
        [MaxLength(50, ErrorMessage ="El {0}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage ="El {0} es obligatorio")]
        public string Name { get; set; }


        [Display(Name = " Persona o Empresa")]
        [MaxLength(50, ErrorMessage = "El {1}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {1} es obligatorio")]
        public string Type { get; set; }


        [Display(Name = "Direccion del cliente")]
        [MaxLength(50, ErrorMessage = "El {2}, no puede tener mas de 50 caractere.")]
        public string Address { get; set; }


        [Display(Name = "telefono fijo o celular")]
        [MaxLength(10, ErrorMessage = "El {3}, no puede tener mas de 10 caractere.")]
        [Required(ErrorMessage = "El {3} es obligatorio")]
        public string Phone { get; set; }

        [Display(Name = "Correo electronico")]
        [MaxLength(50, ErrorMessage = "El {4}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {4} es obligatorio")]
        public string Email { get; set; }

        [Display(Name = "Cedula o Nit de la empresa")]
        [MaxLength(10, ErrorMessage = "El {5}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {5} es obligatorio")]
        public string Nit { get; set; }
    }
}
