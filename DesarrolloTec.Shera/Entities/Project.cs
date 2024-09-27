using
    System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloTec.Shered.Entities
{
    public class Project
    {

        public int Id { get; set; }

        [Display(Name = "Nombre del servicio")]
        [MaxLength(50, ErrorMessage = "El {0}, no puede tener mas de 50 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Name { get; set; }


        [Display(Name = " Estado del proyecto")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Status { get; set; }


        [Display(Name = "Presupuesto")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public decimal Budget { get; set; }


        [Display(Name = " Descripcion del proyecto")]
        [MaxLength(250, ErrorMessage = "El {0}, no puede tener mas de 250 caractere.")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha inicio")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha fin")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime EndDate { get; set; }

        // Envia foranea a ProjectService
        public ICollection<ProjectService> ProjectServices { get; set; }

        // Recibe foranea de customer
        public Customer Customers { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { set; get; }
    }
}
