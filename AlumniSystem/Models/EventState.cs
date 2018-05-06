using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class EventState
    {
        [Key]
        [Column(Order =0)]
        public string Id { get; set; }

        [Key]
        [Column(Order =1)]
        public int EventId { get; set; }

        public int State { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Event Event { get; set; }

    }
}