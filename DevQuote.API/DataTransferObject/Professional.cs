using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevQuote.API.DataTransferObject
{
    public class Professional
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El campo nombre de professional es requerido")]
        public string name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El campo sueldo por mes es requerido")]
        public decimal monthPay { get; set; }

        public List<AssignProject> assignProjects { get; set; }
    }
}
