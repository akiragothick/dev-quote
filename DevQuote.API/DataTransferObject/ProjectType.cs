using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevQuote.API.DataTransferObject
{
    public class ProjectType
    {
        public int id { get; set; }

        public string name { get; set; }

        public List<ProjectTypeMechanism> projectTypeMechanisms { get; set; } 
    }
}
