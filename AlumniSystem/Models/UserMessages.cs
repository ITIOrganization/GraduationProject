using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class UserMessages
    {
        [Key]
        [Column(Order =1)]
        public int Id { get; set; }

        [Column(Order =2)]
        [Key]
        [ForeignKey("ApplicationUser")]
        public string FromId { get; set; }

        [Required]
        public string ToId { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime SendIn { get; set; }

        [DefaultValue(false)]
        public bool IsSeen { get; set; }

        public virtual  ApplicationUser ApplicationUser { get; set; }


    }
}