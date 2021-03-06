﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using HOAHome.Code.Security;
using HOAHome.Areas.nh.Controllers;
using HOAHome.Models;
using HOAHome.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HOAHome.Tests.Controllers.IntegrationTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestAddAndRemoveHomes()
        {
            Guid nhid = new Guid("6B696DBE-616C-4421-9011-D080354977B6");
            var context = new ControllerContext();
            context.RouteData.Values.Add("nhid", nhid.ToString());
            
            var controller = new HomeController();
            controller.ControllerContext = context;

            var result = controller.AddHome("newAddress", 70, -30);
            ViewResult listAction;
            IEnumerable<Home> listOfHomes = null;
            try
            {
                Assert.AreEqual("Homes", ((RedirectToRouteResult)result).RouteValues["action"].ToString());

                
                listAction = controller.Homes();

                
                listOfHomes = (IEnumerable<Home>) controller.ViewData.Model;

                Assert.IsTrue(listOfHomes.Any(h => h.AddressFull == "newAddress"));
            } finally
            {

                //Guid homeId; 
                if (listOfHomes != null)
                {
                    Guid homeId = listOfHomes.Single(h => h.AddressFull == "newAddress").Id;
                    controller.RemoveHome(homeId);
                    listAction = controller.Homes();
                    listOfHomes = (IEnumerable<Home>)controller.ViewData.Model;
                    Assert.IsFalse(listOfHomes.Any(h => h.AddressFull == "newAddress"));

                    bool isThere = false;
                    try
                    {
                        var home = new HOAHome.Repositories.HomeRepository().Get(homeId);
                        isThere = true;
                    }catch
                    {
                    }
                    Assert.IsFalse(isThere,"Home did not get deleted");
                }
                


            }



        }

        private static HomeController GetHomeController(Guid nhid)
        {
            var context = new ControllerContext();
            context.RouteData.Values.Add("nhid", nhid.ToString());

            var controller = new HomeController();
            controller.ControllerContext = context;
            return controller;
        }

        [TestMethod]
        public void TestCannotAddTheSameHouseTwice()
        {
            Guid nhid = new Guid("6B696DBE-616C-4421-9011-D080354977B6");

            var controller = GetHomeController(nhid);

            var result = controller.AddHome("newAddress", 70, -30);
            ViewResult listAction;
            IEnumerable<Home> listOfHomes = null;
            try
            {
                Assert.AreEqual("Homes", ((RedirectToRouteResult)result).RouteValues["action"].ToString());


                listAction = controller.Homes();


                listOfHomes = (IEnumerable<Home>)controller.ViewData.Model;

                Assert.IsTrue(listOfHomes.Any(h => h.AddressFull == "newAddress"));

                controller = GetHomeController(nhid);
                result = controller.AddHome("newAddress", 70, -30);

                Assert.IsFalse(controller.ModelState.IsValid);
                Assert.AreEqual(string.Empty, ((ViewResult)result).ViewName);
            }
            finally
            {

                //Guid homeId; 
                if (listOfHomes != null)
                {
                    Guid homeId = listOfHomes.Single(h => h.AddressFull == "newAddress").Id;

                    controller = controller = GetHomeController(nhid);
                    controller.RemoveHome(homeId);
                    controller = controller = GetHomeController(nhid);
                    listAction = controller.Homes();
                    listOfHomes = (IEnumerable<Home>)controller.ViewData.Model;
                    Assert.IsFalse(listOfHomes.Any(h => h.AddressFull == "newAddress"), "did not get the home removed");

                    bool isThere = false;
                    try
                    {
                        var home = new HOAHome.Repositories.HomeRepository().Get(homeId);
                        isThere = true;
                    }
                    catch
                    {
                    }
                    Assert.IsFalse(isThere, "Home did not get deleted");
                }



            }



        }

    }
}
