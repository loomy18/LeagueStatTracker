using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace LolApiDriver
{
    public static class LeagueApiDriver
    {

        public static string[] Servers = new string[] { "na", "euw" };
        
        public static string getRecentsString(int summonerId, string serverName)
        {
            RestClient client = new RestClient("https://prod.api.pvp.net");
            RestRequest recentRequest = new RestRequest(createRecentString(summonerId, serverName));
            RestResponse recentResponse = (RestResponse)client.Execute(recentRequest);
            return recentResponse.Content;
        }
        public static RecentResponse getRecentsResponse(string recentsString)
        {
            return JsonConvert.DeserializeObject<RecentResponse>(recentsString);
        }
       

        public static string getRankStatsString(int summonerId, string serverName)
        {
            RestClient client = new RestClient("https://prod.api.pvp.net");
            string rankStatRequestString = createStatString(summonerId, serverName, "ranked");
            RestRequest rankStatRequest = new RestRequest(rankStatRequestString);
            RestResponse rankStatResponse = (RestResponse)client.Execute(rankStatRequest);
            return rankStatResponse.Content;
        }
       // public RankStatResponse getRankStatResponse()
        //{
         //   return JsonConvert.DeserializeObject<RankStatResponse>(getRankStatsString());
       // }


        public static string getLeagueUserString(string summonerName, string serverName)
        {
            RestClient client = new RestClient("https://prod.api.pvp.net");
            RestRequest request = new RestRequest(createUserRequestString(summonerName, serverName));
            return client.Execute(request).Content;
        }
        public static Summoner getLeagueUser(string summonerName, string serverName)
        {
            try
            {
                var userDictionary = JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(getLeagueUserString(summonerName, serverName));
                return userDictionary[summonerName];
            }
            catch(Exception e)
            {
                return null;
            }
        }


        public static string createRecentString(int id, string serverName)
        {
            string apiVersion = "v1.3";
            StringBuilder sb = new StringBuilder("/api/lol/");
            sb.Append(serverName);
            sb.Append("/");
            sb.Append(apiVersion);
            sb.Append("/game/by-summoner/");
            sb.Append(id.ToString());
            sb.Append("/recent");
            return addKey(sb.ToString());
        }

        public static string createStatString(int id, string serverName, string statType)
        {
            string apiVersion = "v1.2";
            StringBuilder sb = new StringBuilder("/api/lol/");
            sb.Append(serverName);
            sb.Append("/");
            sb.Append(apiVersion);
            sb.Append("/stats/by-summoner/");
            sb.Append(id.ToString());
            sb.Append("/");
            sb.Append(statType);
            return addKey(sb.ToString());
        }

        public static string createUserRequestString(string summonerName, string serverName)
        {
            string apiVersion = "v1.3";
            StringBuilder sb = new StringBuilder("/api/lol/");
            sb.Append(serverName);
            sb.Append("/");
            sb.Append(apiVersion);
            sb.Append("/summoner/by-name/");
            sb.Append(summonerName);
            return addKey(sb.ToString());
        }

        public static string addKey(string request)
        {
            StringBuilder sb = new StringBuilder(request);
            sb.Append("?api_key=61cabbd3-6250-4a01-a25e-efafe06e5ba8");
            return sb.ToString();
        }
    }
}
