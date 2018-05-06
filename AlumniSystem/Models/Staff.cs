using System;
using System.Collections.Generic;
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

        [Required]
        public string JobTitle { get; set; }

        [ForeignKey("Qualifications")]
        public int QualificationsId { get; set; }

        public Staff()
        {
            Experiences = new List<Experience>();
        }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Track Track { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual Qualifications Qualifications { get; set; }

        public virtual List<Experience> Experiences { get; set; }

    }
}