using DesarrolloTec.Shared.Enums;
using DesarrolloTec.Shered.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaskStatus = DesarrolloTec.Shared.Enums.TaskStatus;


namespace DesarrolloTec.Shared.Entities
{
    public class USerTask
    {
        public int Id { get; set; }

        [Display(Name = " Descripcion de la tarea")]
        [MaxLength(50, ErrorMessage = "El {0}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Description { get; set; }

        [Display(Name = "Fecha de asignacion")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime AssignmateDate { get; set; }

        [Display(Name = "Fecha limite")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime DeadlineDate { get; set; }

        [Display(Name = " Estado de la tarea")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public TaskStatus Status { get; set; }

        [JsonIgnore]
        public Project Projects { get; set; }
        public int ProjectId { get; set; }

        [JsonIgnore]
        public Employee Employees { get; set; }
        public int EmployeeId { get; set; }
    }
}
