using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Complain
    {
        public int Id { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime SendDate { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
   
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}