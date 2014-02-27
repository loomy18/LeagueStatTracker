using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


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
	}
    public class LoginStatus
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string TargetURL { get; set; }
    }
}