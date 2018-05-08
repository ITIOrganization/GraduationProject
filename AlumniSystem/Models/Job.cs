using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Job
    {
        public int Id { get; set; }

        [ForeignKey("JobTitle")]
        public int jobTitleID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public GraduateType GraduateType { get; set; }

        public JobType JobType { get; set; }

        public string Description { get; set; }

        public virtual JobTitle JobTitle { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual List<UsersApplications> UsersApplications { get; set; }
    }
}