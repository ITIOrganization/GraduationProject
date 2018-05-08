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

       
        public Grade Grade { get; set; }

        public Degree Degree { get; set; }

        public virtual List<ApplicationUser> ApplicationUsers { get; set; }

    }
}