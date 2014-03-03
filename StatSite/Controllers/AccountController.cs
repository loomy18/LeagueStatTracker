using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LOLSA.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using LolApiDriver;
using LolApiDriver.Utility;


namespace LOLSA.Controllers
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
            Register register = new Register();
            register.CreateSummonerInfos(1);
            return View(register);
        }
        [HttpPost]
        public ActionResult Register(Register employee)
        {
            // TODO
            return Redirect("New");
        }
        //[HttpPost, ValidateInput(false)]
        //public ActionResult Register(Register model)
        //{
        //    if (ModelState.IsValid) return View(model);
        //    return RedirectToAction("Register", "Account");
        //}

        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
 
        [HttpPost]
        public ActionResult ValidateUser(Login login)
        {
            if (ModelState.IsValid)
            {
                LoginStatus status = new LoginStatus();
                if (Membership.ValidateUser(login.Username, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.Username, login.RememberMe);
                    status.Success = true;
                    status.TargetURL = FormsAuthentication.
                                       GetRedirectUrl(login.Username, login.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        

        [HttpPost]
        //public JsonResult RegisterUser(string Username, string SummonerName, string Email, string Password, string ConfirmPassword, string Question, string QuestionAnswer)
        public ActionResult RegisterUser(Register registerInfo)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus status = new MembershipCreateStatus();
                MembershipUser newUser = Membership.CreateUser(registerInfo.Username, registerInfo.Password, registerInfo.Email, null, null, true, out status);
                switch (status)
                {
                    case MembershipCreateStatus.Success:
                        string[] summonerNames = new string[5];
                        string[] serverNames = new string[5];
                        //summonerNames[0] = registerInfo.Summoner1Name;
                        serverNames[0] = "na";
                        insertSummonerData(registerInfo.Summoners, newUser.ProviderUserKey.ToString());
                        break;
                    default:
                        break;
                }
                return View("login");
            }
            return View("register", registerInfo);
        }

        public void insertSummonerData(ICollection<SummonerInfo> summoners, string userId)
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
                foreach (SummonerInfo summoner in summoners)
                {
                    if (summoner.DeleteSummoner != true)
                    {
                        command.Parameters.AddWithValue(NameParameters[i], summoner.SummonerName);
                        command.Parameters.AddWithValue(IdParameters[i], summoner.SummonerId);
                        command.Parameters.AddWithValue(ServerParameters[i], summoner.Server);
                        i++;
                    }
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