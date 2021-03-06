﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Certification
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        [Required]
        public string Author { get; set; }

        [Required]
        public string ReferenceUrl { get; set; }

        [Required]
        public string CertificationNumber { get; set; }

        [ForeignKey("Graduate")]
        public string GraduateId { get; set; }

        public virtual Graduate Graduate { get; set; }
    }
}