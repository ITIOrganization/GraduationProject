using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Track
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Track")]
        [StringLength(30)]
        public string Name { get; set; }

    }
}