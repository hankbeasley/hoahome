using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.GData.Client;
using System.Xml;
using Google.GData.Extensions;
using HOAHome.Models;
using System.IO;

namespace HOAHome.Code.Google
{
    public class MapDataService
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

        public void Delete(string featureId)
        {
            var service = CreateService();
            service.Delete(new Uri(AddFull(featureId)));
        }

        private static string AddFull(string featureid)
        {
            return featureid.Substring(0, featureid.LastIndexOf('/'))  +  "/full" + featureid.Substring(featureid.LastIndexOf('/'));
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