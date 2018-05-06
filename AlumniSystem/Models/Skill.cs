using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniSystem.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [ForeignKey("Graduate")]
        public string GraduateId { get; set; }

        public virtual Graduate Graduate { get; set; }
    }
}