using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        public TimeSpan PubishedTime { get; set; }

        [DefaultValue(false)]
        public bool IsLiked { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public Post()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<Like> Likes { get; set; }
    }
}