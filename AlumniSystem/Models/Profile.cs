using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Profile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [Required]
        public string CV { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}