using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using RestSharp;

namespace LolApiDriver
{
    public class LolDataDriver
    {
        public static void insertRecentData(int summonerId, string serverName)
        {
            string connectionString = @"Data Source=BRIAN-PC\SQLEXPRESS;Initial Catalog=StatData;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            RecentResponse recents = LeagueApiDriver.getRecentsResponse(LeagueApiDriver.getRecentsString(summonerId, serverName));
            foreach (Game game in recents.games)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("insertGame", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@gameId", game.gameId);
                    command.Parameters.AddWithValue("@summonerId", summonerId);
                    command.Parameters.AddWithValue("@gameMode", game.gameMode);
                    command.Parameters.AddWithValue("@gameType", game.gameType);
                    command.Parameters.AddWithValue("@subType", game.subType);
                    command.Parameters.AddWithValue("@mapId", game.mapId);
                    command.Parameters.AddWithValue("@teamId", game.teamId);
                    command.Parameters.AddWithValue("@championId", game.championId);
                    command.Parameters.AddWithValue("@spell1", game.spell1);
                    command.Parameters.AddWithValue("@spell2", game.spell2);
                    command.Parameters.AddWithValue("@summonerLevel", game.level);
                    command.Parameters.AddWithValue("@createDate", game.createDate);
                    command.Parameters.AddWithValue("@champLevel", game.stats.level);
                    command.Parameters.AddWithValue("@goldEarned", game.stats.goldEarned);
                    command.Parameters.AddWithValue("@numDeaths", game.stats.numDeaths);
                    command.Parameters.AddWithValue("@minionsKilled", game.stats.minionsKilled);
                    command.Parameters.AddWithValue("@championsKilled", game.stats.championsKilled);
                    command.Parameters.AddWithValue("@goldSpent", game.stats.goldSpent);
                    command.Parameters.AddWithValue("@totalDamageDealt", game.stats.totalDamageDealt);
                    command.Parameters.AddWithValue("@totalDamageTaken", game.stats.totalDamageTaken);
                    command.Parameters.AddWithValue("@doubleKills", game.stats.doubleKills);
                    command.Parameters.AddWithValue("@tripleKills", game.stats.tripleKills);
                    command.Parameters.AddWithValue("@killingSprees", game.stats.killingSprees);
                    command.Parameters.AddWithValue("@largestKillingSpree", game.stats.largestKillingSpree);
                    command.Parameters.AddWithValue("@team", game.stats.team);
                    command.Parameters.AddWithValue("@win", game.stats.win);
                    command.Parameters.AddWithValue("@neutralMinionsKilled", game.stats.neutralMinionsKilled);
                    command.Parameters.AddWithValue("@largestMultiKill", game.stats.largestMultiKill);
                    command.Parameters.AddWithValue("@physicalDamageDealtPlayer", game.stats.physicalDamageDealtPlayer);
                    command.Parameters.AddWithValue("@magicDamageDealtPlayer", game.stats.magicDamageDealtPlayer);
                    command.Parameters.AddWithValue("@physicalDamageTaken", game.stats.physicalDamageTaken);
                    command.Parameters.AddWithValue("@magicDamageTaken", game.stats.magicDamageTaken);
                    command.Parameters.AddWithValue("@timePlayed", game.stats.timePlayed);
                    command.Parameters.AddWithValue("@totalHeal", game.stats.totalHeal);
                    command.Parameters.AddWithValue("@totalUnitsHealed", game.stats.totalUnitsHealed);
                    command.Parameters.AddWithValue("@assists", game.stats.assists);
                    command.Parameters.AddWithValue("@item0", game.stats.item0);
                    command.Parameters.AddWithValue("@item1", game.stats.item1);
                    command.Parameters.AddWithValue("@item2", game.stats.item2);
                    command.Parameters.AddWithValue("@item3", game.stats.item3);
                    command.Parameters.AddWithValue("@item4", game.stats.item4);
                    command.Parameters.AddWithValue("@item5", game.stats.item5);
                    command.Parameters.AddWithValue("@item6", game.stats.item6);
                    command.Parameters.AddWithValue("@sightWardsBought", game.stats.sightWardsBought);
                    command.Parameters.AddWithValue("@physicalDamageDealtToChampions", game.stats.physicalDamageDealtToChampions);
                    command.Parameters.AddWithValue("@totalDamageDealtToChampions", game.stats.totalDamageDealtToChampions);
                    command.Parameters.AddWithValue("@trueDamageDealtPlayer", game.stats.trueDamageDealtPlayer);
                    command.Parameters.AddWithValue("@trueDamageDealtToChampions", game.stats.trueDamageDealtToChampions);
                    command.Parameters.AddWithValue("@trueDamageTaken", game.stats.trueDamageTaken);
                    command.Parameters.AddWithValue("@wardPlaced", game.stats.wardPlaced);
                    command.Parameters.AddWithValue("@neutralMinionsKilledEnemyJungle", game.stats.neutralMinionsKilledEnemyJungle);
                    command.Parameters.AddWithValue("@neutralMinionsKilledYourJungle", game.stats.neutralMinionsKilledYourJungle);
                    command.Parameters.AddWithValue("@totalTimeCrowdControlDealt", game.stats.totalTimeCrowdControlDealt);
                    command.Parameters.AddWithValue("@barracksKilled", game.stats.barracksKilled);
                    command.Parameters.AddWithValue("@turretsKilled", game.stats.turretsKilled);
                    command.Parameters.AddWithValue("@largestCriticalStrike", game.stats.largestCriticalStrike);
                    command.Parameters.AddWithValue("@magicDamageDealtToChampions", game.stats.magicDamageDealtToChampions);
                    command.Parameters.AddWithValue("@visionWardsBought", game.stats.visionWardsBought);
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
