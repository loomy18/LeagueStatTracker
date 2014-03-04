using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Sql;
using LOLSA.Models.CustomValidations;
using System.Web.Mvc;

namespace LOLSA.Models
{
    public class Register
    {

        public Register()
        {
            this.Summoners = new HashSet<SummonerInfo>();
        }

        public ICollection<SummonerInfo> Summoners { get; set; }

        [Remote("checkUserName", "Account", HttpMethod="Post", ErrorMessage="User name is already in use")]
        [Required(ErrorMessage = "Username Required:")]
        public string Username { get; set; }

        [Remote("checkEmail", "Account", HttpMethod = "Post", ErrorMessage = "Email is already in use")]
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

        internal void CreateSummonerInfos(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Summoners.Add(new SummonerInfo());
            }
        }
    }
}