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

            var results = repository.Search(new NeighborhoodRepository.SearchCriteria() {Name = "First"});

            Assert.AreEqual(1,results.Count(),"Wrong Number of results");
            Assert.AreEqual("FirstOne", results[0].Name);

        }

        private static IQueryable<Neighborhood> GetTestNeighborhoods()
        {
            return new List<Neighborhood>{ 
                new Neighborhood { Name = "FirstOne" },
                new Neighborhood { Name = "SecondOne" } }.AsQueryable();
        }
    }
}
