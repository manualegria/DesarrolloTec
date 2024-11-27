using DesarrolloTec.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesarrolloTec.Shared.Entities
{
    public class Resource
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del recurso")]
        [MaxLength(50, ErrorMessage = "El {0}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string ResourceName { get; set; }

        [Display(Name = "Tipo de recurso")]
        [MaxLength(50, ErrorMessage = "El {0}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string ResourceType { get; set; }

        [Display(Name = " Descripcion del recurso")]
        [MaxLength(50, ErrorMessage = "El {0}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Description { get; set; }
        
        public Project Projects { get; set; }
        public int ProjectId { get; set; }

    }
}
