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
            SummonerInfo summonerInfo = (SummonerInfo)validationContext.ObjectInstance;
            if (summonerInfo.DeleteSummoner == true) return ValidationResult.Success;
            string serverName = LeagueApiDriver.Servers[summonerInfo.Server];
            string summonerName = summonerInfo.SummonerName;
            LeagueApiDriver driver = new LeagueApiDriver(summonerName, serverName);
            if (driver.user != null)
            {
                summonerInfo.SummonerId = driver.user.id;
                return ValidationResult.Success;
            }
            else return new ValidationResult("Invalid Summoner");
        }
    }
}