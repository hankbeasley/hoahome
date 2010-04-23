using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
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
    }
}
