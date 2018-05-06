using System;
using System.Collections.Generic;
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

        [Required]
        public DateTime EndDate { get; set; }

        [ForeignKey("Graduate")]
        public string GraduateId { get; set; }

        [ForeignKey("Staff")]
        public string StaffId { get; set; }

        public virtual Graduate Graduate { get; set; }

        public virtual Staff Staff { get; set; }

    }
}