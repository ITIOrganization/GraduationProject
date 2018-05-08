using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Like
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        [Column(Order =1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order =2)]
        [ForeignKey("Post")]
        public int PostId { get; set; }
        

        public virtual Post Post { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}