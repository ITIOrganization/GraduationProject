using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Interest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [ForeignKey("Graduate")]
        public string GraduateId { get; set; }

        public virtual Graduate Graduate { get; set; }
    }
}