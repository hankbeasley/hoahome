using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using HOAHome.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HOAHome.Models;
using HOAHome.Controllers;
using System.Web.Mvc;
using HOAHome.Code.Security;

namespace HOAHome.Tests.Controllers
{

    [TestClass]
    public class NeighborhoodControllerTest // : ControllerTestBase<NeighborhoodController, Neighborhood>
    {

        [TestMethod]
        public void TestCreateNewNeighborhood()
        {
            var factory = new FakeRepositoryFactory();

            var entitySubmited = new Neighborhood();
            entitySubmited.Name = "test";


            var controller = new NeighborhoodController(factory);
            factory.MockNeighborhoodRepository.Setup(
                r => r.CreateNew(entitySubmited, Identity_Accessor.TestingAppUser.Id));
            factory.MockNeighborhoodRepository.Setup(r => r.SaveChanges());



            var view = (RedirectToRouteResult)controller.Create(entitySubmited);
            Assert.AreEqual("Details", view.RouteValues["action"]);
            //Assert.AreEqual(Identity_Accessor.TestingAppUser.Id, entitySubmited.PrimaryContactId);

            factory.MockNeighborhoodRepository.VerifyAll();
        }

        [TestMethod]
        public void AddHomeTest()
        {
            var factory = new FakeRepositoryFactory();
            var controller = new NeighborhoodController(factory);
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
            var controller = new NeighborhoodController(factory);
            Guid nhid = Guid.NewGuid();
            var context = new ControllerContext();
            context.RouteData.Values.Add("nhid", nhid);
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
        //[TestMethod]
        //public void CreateNewWithErrorsShouldStayOnTheSamePage()
        //{
        //    var entitySubmited = new Neighborhood();

        //    var mock = GetPersistanceMock();
        //    mock.Setup(p => p.CreateQueryContext<Neighborhood>()).Returns(TestNeighborhoods);

        //    this.Controller.ModelState.AddModelError("Name", "Name is required");
        //    var view = (ViewResult)this.Controller.Create(entitySubmited);
        //    Assert.AreEqual(string.Empty, view.ViewName);

        //    mock.VerifyAll();
        //}


        //[TestMethod]
        //public void NameMustBeUnique()
        //{
        //    var entitySubmited = new Neighborhood();
        //    entitySubmited.Name = "AlreadyThere";
        //    var mock = GetPersistanceMock();
        //    mock.Setup(p => p.CreateQueryContext<Neighborhood>()).Returns(TestNeighborhoods);

        //    var view = (ViewResult)this.Controller.Create(entitySubmited);

        //    Assert.AreEqual("The neighborhood name, AlreadyThere, is already in the system. Please pick another one", Controller.ModelState["Name"].Errors[0].ErrorMessage);

        //    mock.VerifyAll();

        //}

        //[TestMethod]
        //public void LocatedTest()
        //{
        //    var searchString = "11111 Ashcott Dr Houston TX";

        //    var entitySubmited = new Neighborhood();
        //    entitySubmited.Name = "AlreadyThere";
        //    var mock = GetPersistanceMock();
        //    mock.Setup(p => p.CreateQueryContext<Neighborhood>()).Returns(TestNeighborhoods);

        //    var view = (ViewResult)this.Controller.Locate(searchString);

        //    Assert.AreEqual("The neighborhood name, AlreadyThere, is already in the system. Please pick another one", Controller.ModelState["Name"].Errors[0].ErrorMessage);

        //    mock.VerifyAll();

        //}



        //private IQueryable<Neighborhood> TestNeighborhoods
        //{
        //    get
        //    {
        //        var hoods = new List<Neighborhood>();
        //        hoods.Add(new Neighborhood() { Name = "AlreadyThere" });
        //        return hoods.AsQueryable();
        //    }
        //}
    }
}
