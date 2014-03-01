using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using LolApiDriver;


namespace LOLSA.Models.CustomValidations
{
    public class ValidSummonerAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Register register = (Register)validationContext.ObjectInstance;
            string serverName = LeagueApiDriver.Servers[register.Server];
            string summonerName = register.SummonerName;
            LeagueApiDriver driver = new LeagueApiDriver(summonerName, "na");

            if (driver.user != null) return ValidationResult.Success;
            else return new ValidationResult("Invalid Summoner");
        }
    }
}