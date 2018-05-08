﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Image  { get; set; }

        [Required]
        public string Description { get; set; }

        public List<ApplicationUser> ApplicationUsers { get; set; }
    }
}