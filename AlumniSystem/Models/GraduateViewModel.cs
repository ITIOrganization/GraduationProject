using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{
    public class GraduateViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Phone")]
        [RegularExpression("^\\d{11}$", ErrorMessage = "Invalid Phone Number - Must be 11 Digit")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Address { get; set; }

        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }

        public JobTitle JobTitle { get; set; }

        public int Intake { get; set; }

        [Display(Name="Track")]
        public Track Track { get; set; }

        [Display(Name ="Branch")]
        public Branch Branch { get; set; }

    }
}