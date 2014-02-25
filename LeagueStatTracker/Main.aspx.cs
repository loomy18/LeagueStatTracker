using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;
using LeagueStatTracker;
using System.Text;

namespace LeagueStatTracker
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitName_Click(object sender, EventArgs e)
        {
            LeagueUser leagueUser = getLeagueUser();
            RankStatResponse rankStats = getRankStats(leagueUser.id);
            RecentResponse recentStats = getRecentStats(leagueUser.id);
        }

        public RecentResponse getRecentStats(long id)
        {
            RestClient client = new RestClient("https://prod.api.pvp.net");
            RestRequest recentRequest = new RestRequest(createRecentString(id));
            RestResponse recentResponse = (RestResponse)client.Execute(recentRequest);
            return JsonConvert.DeserializeObject<RecentResponse>(recentResponse.Content);
        }

        public RankStatResponse getRankStats(long id)
        {
            RestClient client = new RestClient("https://prod.api.pvp.net");
            string rankStatRequestString = createStatString(id, "summary");
            RestRequest rankStatRequest = new RestRequest(rankStatRequestString);
            RestResponse rankStatResponse = (RestResponse)client.Execute(rankStatRequest);
            return JsonConvert.DeserializeObject<RankStatResponse>(rankStatResponse.Content);
        }


        public LeagueUser getLeagueUser()
        {
            RestClient client = new RestClient("https://prod.api.pvp.net");
            RestRequest request = new RestRequest(createUserRequestString());
            string summonerName = SummonerField.Text;
            RestResponse response = (RestResponse)client.Execute(request);
            var deserializedObject = JsonConvert.DeserializeObject<Dictionary<string, LeagueUser>>(response.Content);
            return deserializedObject[summonerName.ToLower()];
        }


        public string createRecentString(long id)
        {
            string apiVersion = "v1.3";
            string server = ServerSelect.SelectedValue;
            StringBuilder sb = new StringBuilder("/api/lol/");
            sb.Append(server);
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
            string server = ServerSelect.SelectedValue;
            StringBuilder sb = new StringBuilder("/api/lol/");
            sb.Append(server);
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
            string server = ServerSelect.SelectedValue;
            string username = SummonerField.Text;
            StringBuilder sb = new StringBuilder("/api/lol/");
            sb.Append(server);
            sb.Append("/");
            sb.Append(apiVersion);
            sb.Append("/summoner/by-name/");
            sb.Append(username);
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