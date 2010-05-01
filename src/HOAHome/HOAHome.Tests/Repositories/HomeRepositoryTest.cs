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
    public class HomeRepositoryTest
    {
        [TestMethod]
        public void TestGetOrCreateHomeWithExingHomeShouldReturnThatInstance()
        {
            var mockPersistance = new Moq.Mock<IPersistanceFramework>();

            mockPersistance.Setup(m => m.CreateQueryContext<Home>()).Returns(
                TestHomes);

            var repository = new HomeRepository(mockPersistance.Object);

            var results = repository.GetOrCreateHome("first address",1,1);

            Assert.AreEqual(TestHomes.First().Id, results.Id);
            mockPersistance.VerifyAll();
        }

        [TestMethod]
        public void TestGetOrCreateHomeWithNewHomeShouldCreateANewHome()
        {
            var mockPersistance = new Moq.Mock<IPersistanceFramework>();

            mockPersistance.Setup(m => m.CreateQueryContext<Home>()).Returns(
                TestHomes);
            var homeToBeCreated = new Home();
            mockPersistance.Setup(m => m.Create<Home>()).Returns(homeToBeCreated);


            var repository = new HomeRepository(mockPersistance.Object);

            var results = repository.GetOrCreateHome("new address", 1, 1);

            Assert.AreNotEqual(TestHomes.First().Id, results.Id);
            homeToBeCreated.AddressFull = "new address";
            mockPersistance.VerifyAll();
        }

       private IQueryable<Home> TestHomes=
       new List<Home>
                      {
                          new Home()
                              {
                                  Id = Guid.NewGuid(),
                                  AddressFull = "first address"
                             } 
                      }.AsQueryable();
       
    }
}
