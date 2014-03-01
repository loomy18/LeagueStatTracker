using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Sql;
using Test2.Models.CustomValidations;

namespace Test2.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Username Required:")]
        public string UserName { get; set; }
        
        //[ValidSummonerAttribute(ErrorMessage="Invalid Summoner Name")]
        //[Required(ErrorMessage = "Summoner Name Required:")]
        //[DisplayName("Summoner Name:")]
        //[RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Invalid Summoner Name")]
        public string SummonerName { get; set; }
        
        
        public int Server { get; set; }


        [Required(ErrorMessage = "Email required:")]
        [DisplayName("Email:")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Password:")]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{8,})$", ErrorMessage = "Password must be at least 8 characters and contain one numeric character")]
        public string Password { get; set; }

        [System.Web.Mvc.Compare("Password", ErrorMessage="Passwords must match")]
        [Required(ErrorMessage = "Confirm Password Required:")]
        [DisplayName("Confirm Password:")]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{8,})$", ErrorMessage = "Password must be at least 8 characters and contain one numeric character")]
        public string ConfirmPassword { get; set; }
    }
}