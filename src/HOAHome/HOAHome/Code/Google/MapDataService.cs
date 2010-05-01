using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Web;
using Google.GData.Client;
using System.Xml;
using Google.GData.Extensions;
using HOAHome.Models;
using System.IO;
using HOAHome.Repositories;

namespace HOAHome.Code.Google
{
    public class MapDataService : IMapDataService
    {
        const string MAPID = "0004779109f86bbabd62d";
        const string USERID = "208433541473729117510";
        const string DELETEURIFORMAT = "http://maps.google.com/maps/feeds/features/{0}/{1}/full/{2}";//userid,mapid,featureid
        private static Service CreateService()
        {
            var service = new Service("local", "application");
            service.setUserCredentials("hankbeasleymail@yahoo.com", "walmart");
            return service;
        }
        public void AddHome(Home home)
        {
            var service = CreateService();
            var entry = new AtomEntry();
            entry.Title.Text = "Home Zope House";
            entry.Content.Type = "application/vnd.google-earth.kml+xml";
            XmlDocument doc = new XmlDocument();
            string placeMark = string.Format(@"<Placemark xmlns='http://www.opengis.net/kml/2.2'>
                   <name>HomeZope Home</name>
                   <description/>
                   <Point>
                     <coordinates>{0},{1},0.0</coordinates>
                   </Point>
                 </Placemark>", home.Longitude, home.Latitude);
            doc.LoadXml(placeMark);
            entry.Content.ExtensionElements.Add(new XmlExtension(doc.DocumentElement));

            var insertedEntry = service.Insert(new Uri("http://maps.google.com/maps/feeds/features/208433541473729117510/0004779109f86bbabd62d/full"), entry);
            home.GoogleFeatureId = insertedEntry.Id.Uri.ToString();


            //var m = new MemoryStream();
            //insertedEntry.SaveToXml(m);
            //m.Position = 0;
            //var xml = new StreamReader(m).ReadToEnd();

        }


        public IList<Point> GeoCodeAddress(string address)
        {



            //Create a path string with address and api key

            string sPath = "http://maps.google.com/maps/geo?q=" + address + "&output=csv&key=" + Configuration.GoogleApiKey;


            //Using WebClient class to download the CSV
            //WebClient is part of System.Net class

            WebClient client = new WebClient();
            //Downloading CSV with Latitute and Longitute
            //.DownloadString method download CSV file from browser

            List<Point> results = new List<Point>();
            string response = client.DownloadString(sPath);
            foreach (string result in response.Split('\r'))
            {
                string[] eResult = result.Split(',');
                if(eResult.Length != 4) throw new ApplicationException("Google return invalid results");
                //Contract.Assume(eResult[0] != null);
                Contract.Assume(eResult[2] != null);
                Contract.Assume(eResult[3] != null);
                //As you can see, I’m spliting the string into array
                //I’m not using element 0 as it keeps status code if address if found, //but you can if you want too.
                //Once the result / response is in string array eResult, we can access //it by calling its GetValue method and pass the 0 based index.


                int statusCode = int.Parse(eResult[0]);
                if (statusCode == 610) throw new ApplicationException("Bad Key");
                if (statusCode == 620) throw new ApplicationException("Too many queries");
                if (statusCode != 200 && statusCode != 602 && statusCode != 603) throw new ApplicationException("Geocoding error:" + statusCode);

                if (statusCode == 200)
                {
                    Point point = new Point();
                    point.Longitude = double.Parse(eResult[3]);
                    point.Latitude = double.Parse(eResult[2]);

                    results.Add(point);
                }
            }
            return results.AsReadOnly();

        }

        public void Delete(string featureId)
        {
            var service = CreateService();
            service.Delete(new Uri(AddFull(featureId)));
        }

        private static string AddFull(string featureid)
        {
           // Contract.Requires(featureid.LastIndexOf("/") >= 0);
            Contract.Ensures(Contract.Result<string>() != null);
            int lastForwardSlash = featureid.LastIndexOf('/');
            if (lastForwardSlash < 0)
            {
                throw new ArgumentException("must have /", "featureid");
            }

            return featureid.Substring(0, lastForwardSlash) + "/full" + featureid.Substring(lastForwardSlash);
        }

        public bool Exist(string featureId)
        {
            var service = CreateService();

            AtomEntry atom = null;
            try
            {
                atom = service.Get(AddFull(featureId));
            }
            catch (GDataRequestException ex)
            {
                if (ex.ToString().Contains("404"))
                {
                    return false;
                }
                throw;
            }
            return atom != null;
        }

        private static string GetFeatureId(string fullUri)
        {
            return fullUri.Substring(fullUri.LastIndexOf('/') + 1);
        }
    }
}