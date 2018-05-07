﻿using System.ComponentModel.DataAnnotations;

namespace AlumniSystem.Models
{
    public class JobTitle
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}