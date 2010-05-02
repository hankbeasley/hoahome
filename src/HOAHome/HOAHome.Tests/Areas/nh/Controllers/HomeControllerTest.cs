using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using HOAHome.Areas.nh.Controllers;
using HOAHome.Models;
using HOAHome.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HOAHome.Tests.Areas.nh.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void AddHomeTest()
        {
            var factory = new FakeRepositoryFactory();
            var controller = new HomeController(factory);
            Guid nhid = Guid.NewGuid();
            var context = new ControllerContext();
            context.RouteData.Values.Add("nhid", nhid.ToString());
            controller.ControllerContext = context;

            var home = new Home();
            factory.MockHomeRepository.Setup(hr => hr.GetOrCreateHome("newAddress", 1, 1)).Returns(home);
            factory.MockHomeRepository.Setup(hr => hr.SaveChanges());

            factory.MockNeighborhoodRepository.Setup(nr => nr.AddHome(nhid, home));
            factory.MockNeighborhoodRepository.Setup(nr => nr.SaveChanges());

            var result = controller.AddHome("newAddress", 1, 1);

            factory.MockHomeRepository.VerifyAll();
            factory.MockNeighborhoodRepository.VerifyAll();

            Assert.AreEqual("Homes", result.RouteValues["action"].ToString());
        }

        [TestMethod]
        public void ListHomeTest()
        {
            var factory = new FakeRepositoryFactory();
            var controller = new HomeController(factory);
            Guid nhid = Guid.NewGuid();
            var context = new ControllerContext();
            context.RouteData.Values.Add("nhid", nhid.ToString());
            controller.ControllerContext = context;


            factory.MockNeighborhoodRepository.Setup(n => n.GetHomes(nhid)).Returns(TestHomes.ToList());

            var result = controller.Homes();

            factory.MockHomeRepository.VerifyAll();

            // Assert.AreEqual("Homes", result.ViewName);
            Assert.AreEqual(TestHomes.First().AddressFull, ((IList<Home>)result.ViewData.Model).First().AddressFull);
        }

        private IQueryable<Home> TestHomes =
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
