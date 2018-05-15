using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [DefaultValue(false)]
        public int IsApproved { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsFinished { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual List<EventState> EventStates { get; set; }
    }
}