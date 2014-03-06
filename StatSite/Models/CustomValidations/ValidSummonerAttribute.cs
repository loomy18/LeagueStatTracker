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
            Summoner user = LeagueApiDriver.getLeagueUser(summonerName, serverName);
            if (user != null)
            {
                summonerInfo.SummonerId = user.Id;
                summonerInfo.RevisionDate = user.RevisionDate;
                summonerInfo.ProfileIconId = user.ProfileIconId;
                return ValidationResult.Success;
            }
            else return new ValidationResult("Invalid Summoner");
        }
    }
}