﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesarrolloTec.Shered.Entities
{
    public class ProjectService
    {


        public int Id { get; set; }

        public Project Projects { get; set; }
        public int ProjectId { get; set; }

       
        public Service Services { get; set; }
        public int ServicesId { get; set; }


    }
}
