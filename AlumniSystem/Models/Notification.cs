using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime NotifyDate { get; set; }

        [Required]
        public TimeSpan NotifyTime { get; set; }

        [DefaultValue(false)]
        public bool IsRead { get; set; }

        public string Icon { get; set; }

        public string Image { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}