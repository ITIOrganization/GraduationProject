﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Graduate
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [ForeignKey("JobTitle")]
        public int? JobTitleId { get; set; }
        [StringLength(500)]
        public string CareerObjective { get; set; }

        public int Intake { get; set; }

        [ForeignKey("Track")]
        public int TrackId { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual JobTitle JobTitle { get; set; }

        public virtual Track Track { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual List<Certification> Certifications { get; set; }

        public virtual List<Interest> Interests { get; set; }

        public virtual List<Skill> Skills { get; set; }

        public virtual List<Experience> Experiences { get; set; }

        public virtual List<Project> Projects { get; set; }

        public virtual List<UsersApplications> UsersApplications { get; set; }

    }
}