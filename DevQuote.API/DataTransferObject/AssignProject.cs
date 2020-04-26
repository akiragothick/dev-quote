using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevQuote.API.DataTransferObject
{
    public class AssignProject
    {
        public int id { get; set; }

        public int professionalId { get; set; }

        public int projectTypeMechanismId { get; set; }

        public int professionalMonthQuantity { get; set; }

        public bool addProfessional { get; set; }

        public float addProfessionalReducedMonth { get; set; }

        public Professional professional { get; set; }

        public ProjectTypeMechanism projectTypeMechanism { get; set; }
    }
}
