using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace LolApiDriver
{
    public class Driver
    {
        RestClient client = new RestClient("https://prod.api.pvp.net");
        string summonerName {get; set;}
        string serverName {get; set;}
        LeagueUser user {get; set;}

        public Driver(string summonerName, string serverName){
            this.summonerName = summonerName;
            this.serverName = serverName;
            this.user = getLeagueUser(getLeagueUserString());
        }
        
        public string getRecentStatsString()
        {
            RestRequest recentRequest = new RestRequest(createRecentString(user.id));
            RestResponse recentResponse = (RestResponse)client.Execute(recentRequest);
            return recentResponse.Content;
        }
       

        public string getRankStats()
        {
            string rankStatRequestString = createStatString(user.id, "ranked");
            RestRequest rankStatRequest = new RestRequest(rankStatRequestString);
            RestResponse rankStatResponse = (RestResponse)client.Execute(rankStatRequest);
            return rankStatResponse.Content;
        }


        public string getLeagueUserString()
        {
            RestRequest request = new RestRequest(createUserRequestString());
            RestResponse leagueUserResponse = (RestResponse)client.Execute(request);
            return leagueUserResponse.Content;
        }

        public LeagueUser getLeagueUser(string leagueUserString)
        {
             var userDictionary = JsonConvert.DeserializeObject<Dictionary<string, LeagueUser>>(leagueUserString);
             return userDictionary[this.summonerName];
        }


        public string createRecentString(long id)
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

        public string createStatString(long id, string statType)
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

        public string createUserRequestString()
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

        public string addKey(string request)
        {
            StringBuilder sb = new StringBuilder(request);
            sb.Append("?api_key=61cabbd3-6250-4a01-a25e-efafe06e5ba8");
            return sb.ToString();
        }
    }
}
