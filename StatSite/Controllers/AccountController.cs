using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Test2.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using LolApiDriver;
using LolApiDriver.Utility.StringUtil;


namespace Test2.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ValidateUser(string userid, string password,
                                       bool rememberme)
        {
            LoginStatus status = new LoginStatus();
            if (Membership.ValidateUser(userid, password))
            {
                FormsAuthentication.SetAuthCookie(userid, rememberme);
                status.Success = true;
                status.TargetURL = FormsAuthentication.
                                   GetRedirectUrl(userid, rememberme);
                if (string.IsNullOrEmpty(status.TargetURL))
                {
                    status.TargetURL = FormsAuthentication.DefaultUrl;
                }
                status.Message = "Login attempt successful!";
            }
            else
            {
                status.Success = false;
                status.Message = "Invalid UserID or Password!";
                status.TargetURL = FormsAuthentication.LoginUrl;
            }
            return Json(status);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid) return View(model);
            return RedirectToAction("Register", "Account");
        }
        [HttpPost]
        //public JsonResult RegisterUser(string Username, string SummonerName, string Email, string Password, string ConfirmPassword, string Question, string QuestionAnswer)
        public ActionResult RegisterUser(Register registerInfo)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus status = new MembershipCreateStatus();
                MembershipUser newUser = Membership.CreateUser(registerInfo.UserName, registerInfo.Password, registerInfo.Email, null, null, true, out status);
                switch (status)
                {
                    case MembershipCreateStatus.Success:
                        string[] summonerNames = new string[5];
                        string[] serverNames = new string[5];
                        summonerNames[0] = registerInfo.SummonerName;
                        serverNames[0] = "na";
                        insertSummonerData(summonerNames, serverNames, newUser.ProviderUserKey.ToString());
                        break;
                    default:
                        break;
                }
                return View("login");
            }
            return View("register", registerInfo);
        }

        public void insertSummonerData(string[] summonerNames, string[] serverNames, string userId)
        {
            string[] NameParameters = new string[] { "@Summoner1Name", "@Summoner2Name", "@Summoner3Name", "@Summoner4Name", "@Summoner5Name" };
            string[] IdParameters = new string[] { "@Summoner1Id", "@Summoner2Id", "@Summoner3Id", "@Summoner4Id", "@Summoner5Id" };
            string[] ServerParameters = new string[] { "@Summoner1Server", "@Summoner2Server", "@Summoner3Server", "@Summoner4Server", "@Summoner5Server" };
            string connectionString = ConfigurationManager.ConnectionStrings["LeagueStatServer"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("InsertSummoner", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Userid", userId);
                int i = 0;
                while (summonerNames[i] != null)
                {
                    LeagueApiDriver driver = new LeagueApiDriver(summonerNames[i], serverNames[i]);
                    command.Parameters.AddWithValue(NameParameters[i], summonerNames[i]);
                    command.Parameters.AddWithValue(IdParameters[i], driver.user.id);
                    command.Parameters.AddWithValue(ServerParameters[i], serverNames[i]);
                    i++;
                }
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }



    public class LoginStatus
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string TargetURL { get; set; }
    }
}