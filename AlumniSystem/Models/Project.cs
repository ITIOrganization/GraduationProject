using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace AlumniSystem.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        [ForeignKey("Graduate")]
        public string GraduateId { get; set; }

        public virtual Graduate Graduate { get; set; }
    }
}