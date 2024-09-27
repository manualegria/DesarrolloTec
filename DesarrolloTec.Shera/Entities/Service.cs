using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloTec.Shered.Entities
{
    public class Service
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del servicio")]
        [MaxLength(50, ErrorMessage = "El {0}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Name { get; set; }


        [Display(Name = " Descripcion del servicio")]
        [MaxLength(250, ErrorMessage = "El {0}, no puede tener mas de 250 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Description { get; set; }


        [Display(Name = "Precio estimado para e servicio")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public decimal EstimatedPrice { get; set; }



    }
}
