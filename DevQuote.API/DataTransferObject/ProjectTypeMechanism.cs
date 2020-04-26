using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevQuote.API.DataTransferObject
{
    public class ProjectTypeMechanism
    {
        public int id { get; set; }

        public int projectTypeId { get; set; }

        public string name { get; set; }

        public float devMonthsQuantity { get; set; }

        public ProjectType projectType { get; set; }
        
        public List<AssignProject> assignProjects { get; set; } 
    }
}
