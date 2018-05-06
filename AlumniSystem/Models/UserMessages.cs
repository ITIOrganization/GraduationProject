using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class UserMessages
    {
        [Key]
        [Column(Order =0)]
        public string FromId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MessageId { get; set; }

        [Key]
        [Column(Order =2)]
        public string ToId { get; set; }


        public virtual  ApplicationUser ApplicationUser { get; set; }

        public virtual Message Message { get; set; }








    }
}