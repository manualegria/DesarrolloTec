using DesarrolloTec.Shered.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesarrolloTec.Shared.Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de expedición")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime DateIssued { get; set; }

        [Display(Name = "Monto total")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public decimal TotalAmount { get; set; }

        [Display(Name = " Estado del pago")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string PaymentStatus { get; set; }

      
        public Customer Customers { get; set; }
        public int CustomerId { get; set; }

        
        public Project Projects { get; set; }
        public int ProjectId { get; set; }


    }
}
