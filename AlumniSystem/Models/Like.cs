using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Like
    {
        public int Id { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
  
    }
}