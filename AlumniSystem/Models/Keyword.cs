using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Keyword
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [DefaultValue(false)]
        public int Priority { get; set; }

        public virtual List<ApplicationUser> ApplicationUsers { get; set; }
    }
}