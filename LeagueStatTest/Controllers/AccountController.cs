using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace LeagueStatTest.Account
{
    public class AccountController : Controller
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        public ActionResult Login()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public string ValidateUser(string userid, string password,
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
            return JsonConvert.SerializeObject(status);
        }
    }
    public class LoginStatus
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string TargetURL { get; set; }
    }
}