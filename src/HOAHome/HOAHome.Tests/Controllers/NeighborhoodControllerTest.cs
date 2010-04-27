using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
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


            var controller = new NeighborhoodController(factory.Neighborhood);
            factory.MockNeighborhoodRepository.Setup(
                r => r.CreateNew(entitySubmited, Identity_Accessor.TestingAppUser.Id));
            factory.MockNeighborhoodRepository.Setup(r => r.SaveChanges());



            var view = (RedirectToRouteResult)controller.Create(entitySubmited);
            Assert.AreEqual("Details", view.RouteValues["action"]);
            //Assert.AreEqual(Identity_Accessor.TestingAppUser.Id, entitySubmited.PrimaryContactId);

            factory.MockNeighborhoodRepository.VerifyAll();
        }

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
