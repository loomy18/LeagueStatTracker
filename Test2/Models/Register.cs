using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using System.Data.Sql;

namespace Test2.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Username Required:")]
        [DisplayName("First Name:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters are not allowed")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Summoner Name Required:")]
        [DisplayName("Summoner Name:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters are not allowed")]
        public string SummonerName { get; set; }

        [Required(ErrorMessage = "Email required:")]
        [DisplayName("Email:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters are not allowed")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Question required:")]
        [DisplayName("Question:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters are not allowed")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Question answer required:")]
        [DisplayName("Question Answer:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters are not allowed")]
        public string QuestionAnswer { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Password:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters are not allowed")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required:")]
        [DisplayName("Confirm Password:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters are not allowed")]
        public string ConfirmPassword { get; set; }
    }
}