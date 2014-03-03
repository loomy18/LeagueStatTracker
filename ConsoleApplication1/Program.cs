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
            string connectionString = ConfigurationManager.ConnectionStrings["LeagueStatServer"].ConnectionString;
            LolsaDataClassesDataContext dc = new LolsaDataClassesDataContext(connectionString);
            var summonerIds = dc.getSummonerIds();

        }
    }
}
