using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOAHome.Code
{
    public class Configuration
    {
        public const string ConsumerKey = "www.speedhq.com";
        public static string GoogleApiKey
        {
            get
            {

                return System.Configuration.ConfigurationManager.AppSettings["GoogleApiKey"];
            }
        }

        public static string ConnectionString { get { return @"Data Source=localhost;Initial Catalog=HOAHomeDB;Integrated Security=True;MultipleActiveResultSets=True"; } }
    }
}