using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HOAHome.Code.EntityFramework;
using HOAHome.Controllers;
using HOAHome.Models;

namespace HOAHome.Tests.Controllers
{
    [TestClass]
    public class UserHomeControllerTest
    {
        [TestMethod]
        public void TestCreatingUserHomeWithNewHome()
        {
            var mock = new Moq.Mock<IPersistanceFramework>();
            var controller = new UserHomeController();
            UserHomeController_Accessor.AttachShadow(controller).Persistance = mock.Object;
            mock.Setup(p => p.CreateQueryContext<Home>()).Returns(HomesList);
            var newHomeThatShouldBeCreated = new Home();
            mock.Setup(p => p.Create<Home>()).Returns(newHomeThatShouldBeCreated);
            mock.Setup(p => p.SaveChanges());
            
            var enteredHome = new UserHome();
            enteredHome.Name = "TestName";
            
            var userId = Guid.NewGuid();
            controller.CreateChildByAddress(userId, enteredHome, "TestAddress", 1, 1);

            Assert.AreEqual(userId, enteredHome.AppUserId);
            Assert.AreEqual("TestAddress", enteredHome.Home.AddressFull);

            mock.VerifyAll();

        }

        [TestMethod]
        public void TestCreatingUserHomeWithExistingHome()
        {
            var mock = new Moq.Mock<IPersistanceFramework>();
            var controller = new UserHomeController();
            UserHomeController_Accessor.AttachShadow(controller).Persistance = mock.Object;
            var existingHome = new Home();
            mock.Setup(p => p.CreateQueryContext<Home>()).Returns(HomesList);
            
            mock.Setup(p => p.SaveChanges());

            var enteredHome = new UserHome();
            enteredHome.Name = "TestName";

            var userId = Guid.NewGuid();
            controller.CreateChildByAddress(userId, enteredHome, "Existing address", 1, 1);

            Assert.AreEqual(userId, enteredHome.AppUserId);
            Assert.AreEqual("Existing address", enteredHome.Home.AddressFull);

            mock.VerifyAll();

        }

        private IQueryable<Home> HomesList
        {
            get
            {
                var homes = new List<Home>();
                homes.Add(new Home() { AddressFull = "Existing address" });
                return homes.AsQueryable();
            }
        }

    }
}
