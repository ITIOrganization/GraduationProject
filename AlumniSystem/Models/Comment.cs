using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Comment
    {
        
        [Key]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Required]
        public string Body { get; set; }

        
        [Key]
        [Column(Order =2)]
        [ForeignKey("Post")]
        public int PostId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Post Post { get; set; }

    }
}