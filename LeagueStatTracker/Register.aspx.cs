using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LolApiDriver;
using System.Data.SqlClient;
using System.Configuration;

namespace LeagueStatTracker
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void registerClick(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["LeagueStatServer"].ConnectionString;
            LeagueApiDriver driver = new LeagueApiDriver(SummonerNameField.Text, ServerSelect.SelectedValue);
            LeagueUser user = driver.user;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand("insertUser", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", UserField.Text);
                command.Parameters.AddWithValue("@SummonerName", SummonerNameField.Text);
                command.Parameters.AddWithValue("@Pass", PasswordField.Text);
                command.Parameters.AddWithValue("@SummonerId", user.id);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
        protected void SummonerValidation(object sender, ServerValidateEventArgs e)
        {
            LeagueApiDriver driver = new LeagueApiDriver(SummonerNameField.Text, ServerSelect.SelectedValue);
            LeagueUser user = driver.user;
            e.IsValid = (user != null);
        }
    }
}