using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesarrolloTec.Shered.Entities
{
    public class EmployeeProject
    {

        public int Id { get; set; }

      
        public Project Projects { get; set; }
        public int ProjectId { get; set; }

      
        public Employee Employees { get; set; }
        public int EmployeeId { get; set; }

        public DateTime AssignedDate { get; set; }

    }
}
