using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Linq;
using DataScript.Tables;
using LolApiDriver;
namespace DataScript
{
    class Program
    {
        static void Main(string[] args)
        {
            getSummonerIds();
        }
        public static void getSummonerIds()
        {

            Summoner user = LeagueApiDriver.getLeagueUser("loomi", "na");
            LolsaDataClassesDataContext dc = new LolsaDataClassesDataContext(ConfigurationManager.ConnectionStrings["LeagueStatServer"].ConnectionString);
            Table<Summoner> Summoners = dc.GetTable<Summoner>();
        }
    }
}
