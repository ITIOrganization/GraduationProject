using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Qualifications
    {
        public int Id { get; set; }

        [Required]
        public string University { get; set; }

        [Required]
        public string Faculty { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        [Required]
        public DateTime GraduateDate { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        [StringLength(20)]
        public string Grade { get; set; }

        [Required]
        [Range(0,100)]
        public int Degree { get; set; }

    }
}