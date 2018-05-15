using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Staff
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [ForeignKey("Track")]
        public int TrackId { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [ForeignKey("JobTitle")]
        public int JobTitleId { get; set; }

        [DefaultValue(false)]
        public bool IsApproved { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Track Track { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual JobTitle JobTitle { get; set; }

        public virtual List<Experience> Experiences { get; set; }

       

    }
}