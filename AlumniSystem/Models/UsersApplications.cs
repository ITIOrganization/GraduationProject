using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class UsersApplications
    {
        [Key]
        [ForeignKey("Graduate")]
        [Column(Order =1)]
        public string Id { get; set; }

        [Key]
        [Column(Order =2)]
        [ForeignKey("Job")]
        public int JobId { get; set; }

        public DateTime AppliedDate { get; set; }

        [DefaultValue(false)]
        public bool IsApplied { get; set; }

        public virtual  Graduate Graduate { get; set; }

        public virtual Job Job { get; set; }


    }
}