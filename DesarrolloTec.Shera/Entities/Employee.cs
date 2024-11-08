using DesarrolloTec.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesarrolloTec.Shered.Entities
{
    public class Employee
    {

        public int Id { get; set; }

        [Display(Name = "Nombre del Empleado")]
        [MaxLength(50, ErrorMessage = "El {0}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string LastName { get; set; }

        [Display(Name = "Nombre del Empleado")]
        [MaxLength(50, ErrorMessage = "El {0}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string FirstName { get; set; }


        [Display(Name = "Cargo del empleado")]
        [MaxLength(10, ErrorMessage = "El {0}, no puede tener mas de 10 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Position { get; set; }

        [Display(Name = "Especializacion del empleado")]
        [MaxLength(50, ErrorMessage = "El {0}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Specialization { get; set; }

        [Display(Name = "Correo electronico")]
        [MaxLength(50, ErrorMessage = "El {0}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Email { get; set; }

        [Display(Name = "telefono fijo o celular")]
        [MaxLength(10, ErrorMessage = "El {0}, no puede tener mas de 10 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Phone { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [JsonIgnore]
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }

        [JsonIgnore]
        public ICollection<USerTask> USerTasks { get; set; }
    }
}

