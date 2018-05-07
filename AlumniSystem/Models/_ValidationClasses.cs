using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlumniSystem.Models
{

    //Age between 17-80
    public class DateOfBirthValidate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            if (date.Year < DateTime.Now.AddYears(-100).Year || date.Year > DateTime.Now.AddYears(-22).Year)
                return false;
            else
                return true;
        }

    }
    //file Must Be Image
    public class FormFileValidate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            HttpPostedFileBase file = (HttpPostedFileBase)value;
            if (!file.ContentType.Contains("image"))
            {
                return false;
            }
            return true;
        }
    }
}