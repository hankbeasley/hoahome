using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HOAHome.Code.EntityFramework;
using HOAHome.Models;
using HOAHome.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HOAHome.Tests.Repositories
{
    [TestClass]
    public class NeighborhoodRepositoryTest
    {
        [TestMethod]
        public void SearchByNameTest()
        {
            var mockPersistance = new Moq.Mock<IPersistanceFramework>();

            mockPersistance.Setup(m => m.CreateQueryContext<Neighborhood>()).Returns(
                GetTestNeighborhoods());

            NeighborhoodRepository repository = new NeighborhoodRepository(mockPersistance.Object);

            var results = repository.FindBySimilarName("First");

            Assert.AreEqual(1,results.Count(),"Wrong Number of results");
            Assert.AreEqual("FirstOne", results[0].Name);

        }


        //Real DB Test
        [TestMethod]
        public void SearchByDistanceTest()
        {

            NeighborhoodRepository repository = new NeighborhoodRepository(new PersistanceFramework(new COHHomeEntities()));

            //Ashcott
            Point point = new Point { Longitude = -95.574233, Latitude = 29.707864 };

            var closeHoods = repository.FindNearPoint(point);

            Assert.AreEqual(1,closeHoods.Count(n=>n.Id == TestNeighborHoodId),"Aschott should be near Brays Village");
          

            //Kim Son
            point = new Point { Longitude = -95.567014, Latitude = 29.704069 };

            closeHoods = repository.FindNearPoint(point);

            Assert.AreEqual(1, closeHoods.Count(n => n.Id == TestNeighborHoodId), "Kim Son should be near Brays Village");


            //6015 Skyline
            point = new Point { Longitude = -95.484719, Latitude = 29.728415 };

            closeHoods = repository.FindNearPoint(point);

            Assert.AreEqual(0, closeHoods.Count(n => n.Id == TestNeighborHoodId), "Skyline should not be near Brays Village");

        }

        //[ClassInitialize]
        //public void SetupNeighborHoodTestData()
        //{
        //    var persistance = new PersistanceFramework(new COHHomeEntities());
        //    var neighborHood = persistance.Create<Neighborhood>();
        //    neighborHood.Id = TestNeighborHoodId;
        //    neighborHood.KML = ""
        //}

        
        //already in db
        private readonly Guid TestNeighborHoodId = new Guid("6B696DBE-616C-4421-9011-D080354977B6");
        //Alief
        //private const string TestKLM =
        //    "POLYGON((-95.57532548904419 29.703478878844557,-95.57004690170288 29.712834801678493,-95.57438135147095 29.715220236151897,-95.57815790176392 29.704410782755083,-95.57532548904419 29.703478878844557)) ";

        private static IQueryable<Neighborhood> GetTestNeighborhoods()
        {
            return new List<Neighborhood>{ 
                new Neighborhood { Name = "FirstOne" },
                new Neighborhood { Name = "SecondOne" } }.AsQueryable();
        }
    }
}
