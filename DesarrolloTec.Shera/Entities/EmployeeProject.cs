using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloTec.Shered.Entities
{
    public class EmployeeProject
    {

        public int Id { get; set; }

        public Project Projects { get; set; }

        public Employee Employees { get; set; }

    }
}
