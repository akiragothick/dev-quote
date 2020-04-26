using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevQuote.API.Models
{
    public class ProjectTypeMechanism
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string name { get; set; }

        public float devMonthsQuantity { get; set; }

        [ForeignKey("ProjectType")]
        public int projectTypeId { get; set; }
        public ProjectType projectType { get; set; }

        public List<AssignProject> assignProjects { get; set; } = new List<AssignProject>();
    }
}
