using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;

namespace LOLSA.Models.CustomValidations
{
    public class UniqueUsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool unique = Membership.GetUser(value.ToString()) == null;
            if (unique) return ValidationResult.Success;
            else return new ValidationResult("Username Taken");
        }
    }
}