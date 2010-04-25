using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using HOAHome.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HOAHome.Code.Google;
using HOAHome.Models;

namespace HOAHome.Tests.Google
{
    [TestClass]
    public class MapDataServiceTest
    {
        [TestMethod]
        public void InsertExistDeleteTest()
        {
            var service = new MapDataService();
            var home = new Home();
            home.Latitude = -89.520753;
            home.Longitude = 34.360902;
            service.AddHome(home);

            Assert.IsFalse(string.IsNullOrEmpty(home.GoogleFeatureId));
            Assert.IsTrue(service.Exist(home.GoogleFeatureId));
            service.Delete(home.GoogleFeatureId);
            Assert.IsFalse(service.Exist(home.GoogleFeatureId));
        }

        [TestMethod]
        public void GeoCodeTest()
        {
            var service = new MapDataService();


            //Ashcott
            Point expected = new Point { Longitude = -95.574233, Latitude = 29.707864 };

            var actual = service.GeoCodeAddress("11111 Ashcott Dr 77072");

            Assert.AreEqual(expected.Longitude,actual[0].Longitude, 0.0005);
            Assert.AreEqual(expected.Latitude, actual[0].Latitude, 0.0005);


            ////6015 Skyline
            //expected = new Point { Longitude = -95.484719, Latitude = 29.728415 };
            //actual = service.GeoCodeAddress("6015 Skyline");
        }
    }
}
