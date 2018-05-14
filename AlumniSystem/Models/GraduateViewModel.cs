using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [Remote("CheckPhone","Admin",ErrorMessage ="This Phone Is Already Exist")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [Remote("CheckEmail", "Admin", ErrorMessage = "This Email Is Already Exist")]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }

        public JobTitle JobTitle { get; set; }

        public int Intake { get; set; }

        [Display(Name="Track")]
        public int TrackId { get; set; }

        [Display(Name ="Branch")]
        public int BranchId { get; set; }

    }
}