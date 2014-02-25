using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Web.Script.Serialization;

namespace LeagueStatTracker
{
    public class LeagueUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public long revisionDate { get; set; }
    }
}