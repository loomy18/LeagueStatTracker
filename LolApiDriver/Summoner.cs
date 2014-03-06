using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RestSharp;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LolApiDriver
{
    [Table(Name="SummonerTable")]
    public class Summoner
    {
        [Column(IsPrimaryKey=true)]
        public int Id { get; set; }
        [Column]
        public int Server { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public long RevisionDate { get; set; }
        [Column]
        public int ProfileIconId { get; set; }
    }
}