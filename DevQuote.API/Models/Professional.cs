using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevQuote.API.Models
{
    public class Professional
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string name { get; set; }

        [Column(TypeName = "decimal(20,10)")]
        public decimal monthPay { get; set; }

        public List<AssignProject> assignProjects { get; set; } = new List<AssignProject>();
    }
}
