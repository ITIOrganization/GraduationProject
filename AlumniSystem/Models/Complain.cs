using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Complain
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public DateTime SendDate { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
   
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}