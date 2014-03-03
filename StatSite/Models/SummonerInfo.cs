using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LOLSA.Models.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace LOLSA.Models
{
    public class SummonerInfo
    {
        public  SummonerInfo()
        {
            this.Servers = new SelectList(
                   new List<Object>{
                       new { value = 0 , text = "NA"  },
                       new { value = 1 , text = "EUW" },
                    },
                   "value",
                   "text",
                    0);
        }
        public SelectList Servers { get; set; }
        public int Server { get; set; }
        
        [ValidSummonerAttribute(ErrorMessage="Invalid Summoner Name")]
        public string SummonerName { get; set; }
        public bool DeleteSummoner { get; set; }
        public int SummonerId { get; set; }
    }
}