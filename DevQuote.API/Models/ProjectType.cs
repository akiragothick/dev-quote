using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevQuote.API.Models
{
    public class ProjectType
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string name { get; set; }

        public List<ProjectTypeMechanism> projectTypeMechanisms { get; set; } = new List<ProjectTypeMechanism>();
    }
}
