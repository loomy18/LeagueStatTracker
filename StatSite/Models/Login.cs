using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LOLSA.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Username Required:")]
        [DisplayName("Username:")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Password:")]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{8,})$", ErrorMessage = "Password must be at least 8 characters and contain one numeric character")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}