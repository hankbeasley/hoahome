using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HOAHome.Code.Google;
using HOAHome.Code.EntityFramework;
using Moq;
using HOAHome.Models;

namespace HOAHome.Tests.Google
{
    [TestClass]
    public class GoogleOAuthTest
    {
        [TestMethod]
        public void TestSyncUsersWithExistingUser()
        {
            List<AppUser> users = CreateTestUsers();
            var mock = new Mock<IPersistanceFramework>();
            mock.Setup(p => p.CreateQueryContext<AppUser>()).Returns(users.AsQueryable());
            mock.Setup(p => p.SaveChanges());

            var claimedUser = new AppUser() { GoogleId = "testid1", FirstName="googleName" };
            AppUser syncedUser = (AppUser)new PrivateType(typeof(GoogleOAuth)).InvokeStatic("SyncUserWithHOAHome", claimedUser, mock.Object);
            //var syncedUser = GoogleOAuth_Accessor.SyncUserWithHOAHome(claimedUser, mock.Object);

            Assert.AreEqual("HoaName", syncedUser.FirstName);
            Assert.AreEqual("HoaName", users[0].FirstName);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestSyncUsersWithNewUser()
        {
             var claimedUser = new AppUser() { GoogleId = "newId", FirstName = "googleName", LastName="googleLastName" };

            List<AppUser> users = CreateTestUsers();
            var mock = new Mock<IPersistanceFramework>();
            mock.Setup(p => p.CreateQueryContext<AppUser>()).Returns(users.AsQueryable());
            mock.Setup(p => p.AttachNew(claimedUser));
            mock.Setup(p => p.SaveChanges());

            AppUser syncedUser = (AppUser)new PrivateType(typeof(GoogleOAuth)).InvokeStatic("SyncUserWithHOAHome", claimedUser, mock.Object);
           
            //var syncedUser = GoogleOAuth_Accessor.SyncUserWithHOAHome(claimedUser, mock.Object);

            Assert.AreEqual("googleName", syncedUser.FirstName);
            Assert.AreEqual("googleLastName, googleName", syncedUser.DisplayName);


            mock.VerifyAll();
            
        }


        private static List<AppUser> CreateTestUsers()
        {
            List<AppUser> users = new List<AppUser>();

            users.Add(new AppUser() {GoogleId="testid1", FirstName="HoaName" });
            users.Add(new AppUser() { GoogleId = "testid2" });
            return users;
        }
    }
}
