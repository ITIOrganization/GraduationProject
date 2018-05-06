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
        [StringLength(30)]
        public string Name { get; set; }

        public Track()
        {
            Graduates = new List<Graduate>();
        }
        public virtual List<Graduate> Graduates { get; set; }
    }
}