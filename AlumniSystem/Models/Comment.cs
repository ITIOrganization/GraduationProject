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
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        [DefaultValue(false)]
        public bool IsLiked { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Post Post { get; set; }

    }
}