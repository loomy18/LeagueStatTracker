using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Test2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MembershipCreateStatus status1;
            Membership.CreateUser("loomy18",
            "aLergery.10859", "test2@somewebsite.com",
            "question", "answer", true, out status1);
        }
    }
}
