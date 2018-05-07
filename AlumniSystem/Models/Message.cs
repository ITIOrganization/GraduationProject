using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime SendIn { get; set; }

        [DefaultValue(false)]
        public bool IsSeen { get; set; }


        public virtual List<UserMessages> UserMessages { get; set; }
    }
}