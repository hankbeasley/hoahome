using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HOAHome.Code.EntityFramework;
using HOAHome.Models;
using HOAHome.Services;

namespace HOAHome.Tests.Services
{
    [TestClass]
    public class GisServiceTest
    {
        PersistanceFramework persistance = new PersistanceFramework(new HOAHome.Models.COHHomeEntities());
        private AppUser user;
        private Neighborhood neighborhood;
        [TestInitialize]
        public void Init()
        {
            user = persistance.Create<AppUser>();
            user.DisplayName = "test2";
            user.Email = "test";
            user.GoogleId = "test";
            neighborhood = persistance.Create<Neighborhood>();
            neighborhood.Name = "test2";
            neighborhood.KML = "POLYGON((-87 30, -85 30, -86 31, -87 30))";
            neighborhood.PrimaryContact = user;
            persistance.SaveChanges();
        }
        [TestCleanup]
        public void CleanUp()
        {
            persistance.Delete<AppUser>(user.Id);
            persistance.Delete<Neighborhood>(neighborhood.Id);
            persistance.SaveChanges();

        }
        [TestMethod]
        public void TestPointInAndOutOfTheTriangle()
        {
            var service = new GisService();

            Assert.IsTrue(service.GetIntersectingNeighborhoods(-86, 30.5).Count(n => n.Id == neighborhood.Id) == 1);
            Assert.IsTrue(service.GetIntersectingNeighborhoods(-89, 30.5).Count(n => n.Id == neighborhood.Id) == 0);
        }
    }
}
