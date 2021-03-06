﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DevQuote.API.Models
{
    public class AssignProject
    {
        [Key]
        public int id { get; set; }

        public int professionalMonthQuantity { get; set; }

        public bool addProfessional { get; set; }

        public float addProfessionalReducedMonth { get; set; }


        [ForeignKey("Professional")]
        public int professionalId { get; set; }
        public Professional professional { get; set; }


        [ForeignKey("ProjectTypeMechanism")]
        public int projectTypeMechanismId { get; set; }
        public ProjectTypeMechanism projectTypeMechanism { get; set; }
    }
}
