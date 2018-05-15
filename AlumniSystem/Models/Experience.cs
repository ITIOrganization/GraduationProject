using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Experience
    {
        public int Id { get; set; }

        public string OrganizationName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsCusrrentlyWorked { get; set; }

        [ForeignKey("JobTitle")]
        public int JobTitleId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual JobTitle JobTitle { get; set; }

    }
}