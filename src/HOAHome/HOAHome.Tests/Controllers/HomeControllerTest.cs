﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using HOAHome.Models;
using HOAHome.Repositories;
using HOAHome.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HOAHome;
using HOAHome.Controllers;
using Google.GData.Client;
using System.IO;
using Google.GData.Extensions;
using System.Xml;
using Moq;
using HOAHome.Code.Google;

namespace HOAHome.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest 
    {
        private class MapsExtension : ExtensionBase
        {
            public MapsExtension() : base("Placemark", "m", "http://www.opengis.net/kml/2.2") {
                //this.Value = "stuff";
            }

            public override void SaveInnerXml(XmlWriter writer)
            {
                base.SaveInnerXml(writer);
                writer.WriteRaw("stuff");
            }
            public override void Save(XmlWriter writer)
            {
                base.Save(writer);
            }
        }

        private class MapElement : AtomEntry
        {
            protected override void AddOtherNamespaces(XmlWriter writer)
            {
                base.AddOtherNamespaces(writer);
                writer.WriteAttributeString("xmlns:m", null, "http://www.opengis.net/kml/2.2");
            }
        }
        [TestMethod]
        public void Index()
        {


            var g = new Service("local", "application");//, "ABQIAAAACPMbozlNv9AIzNvsWUm6vhSvnLMDprvOSMH9Qt_oH5Ww7FTw1hRHT7gTSie1yM34rowNwVfw424XPA");
            
            Assert.Fail("Need to put password here");
            g.setUserCredentials("hankbeasleymail@yahoo.com", "zzz");
            var entry = new AtomEntry();
            entry.Content.ExtensionFactories.Add(new MapsExtension());
            entry.Title.Text = "test";
           entry.Content.Type = "application/vnd.google-earth.kml+xml";
           XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<Placemark xmlns='http://www.opengis.net/kml/2.2'>
                   <name>Faulkner's Birthplace</name>
                   <description/>
                   <Point>
                     <coordinates>-89.520753,34.360902,0.0</coordinates>
                   </Point>
                 </Placemark>");
            entry.Content.ExtensionElements.Add(new XmlExtension((XmlNode)doc.DocumentElement));
                 //    doc.LoadXml(@"@"<m:Placemark>
                 //  <m:name>Faulkner's Birthplace</m:name>
                 //  <m:description/>
                 //  <m:Point>
                 //    <m:coordinates>-89.520753,34.360902,0.0</m:coordinates>
                 //  </m:Point>
                 //</m:Placemark>";

            //entry.Content.Content = ;
            //entry.AddExtension(new MapsExtension());
            var m = new MemoryStream();
            //var mapStuff = entry.Content.CreateExtension("PlaceMark", "http://www.opengis.net/kml/2.2");

            
           // entry.Update();
            try
            {
                entry.SaveToXml(m);
            }
            catch (Exception e)
            {
                var s = e.ToString();
                throw;
            }
            m.Position = 0;
            var mm = new StreamReader(m).ReadToEnd();
             var q = g.Insert(new Uri("http://maps.google.com/maps/feeds/features/208433541473729117510/0004779109f86bbabd62d/full"), entry);

            var p = g.Query(new Uri("http://maps.google.com/maps/feeds/maps/default/full"));

            var z = new StreamReader(p).ReadToEnd();

            //// Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.Index() as ViewResult;

            //// Assert
            //ViewDataDictionary viewData = result.ViewData;
            //Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestSearchByName()
        {
          
            

            // Arrange
            var fakeRepository = new FakeRepositoryFactory();
            var mockMapServer = new Mock<IMapDataService>();
            HomeController controller = new HomeController(fakeRepository, mockMapServer.Object);
            //HomeController.SearchCriteria criteria = new HomeController.SearchCriteria();
            //criteria.Name = "Brays";
            string search = "Brays";
            fakeRepository.MockNeighborhoodRepository.Setup(n => n.FindBySimilarName(search)).Returns(new List<Neighborhood>{new Neighborhood{Name="Brays Village"}});
            mockMapServer.Setup(m => m.GeoCodeAddress(search)).Returns(new List<Point>());
            // Act
            ViewResult result = controller.DisplaySearchResults(search) as ViewResult;

            var resultList = result.ViewData.Model as IList<Models.Neighborhood>;

            // Assert
            Assert.IsNotNull(resultList);
            Assert.AreEqual("Brays Village",resultList[0].Name);
            //Assert.AreEqual("DisplaySearchResults", result.ViewName);
        }


        [TestMethod]
        public void TestSearchByAddress()
        {
            // Arrange
            var fakeRepository = new FakeRepositoryFactory();
            var mockMapServer = new Mock<IMapDataService>();

            var address = "The Address";
            var geoCodedPoints = new List<Point>
                                     {new Point {Longitude = 1, Latitude = 2}, new Point {Longitude = 3, Latitude = 4}};

            mockMapServer.Setup(m => m.GeoCodeAddress(address)).Returns(geoCodedPoints);
            fakeRepository.MockNeighborhoodRepository.Setup(n => n.FindBySimilarName(address)).Returns(new List<Neighborhood>());
          
            fakeRepository.MockNeighborhoodRepository.Setup(n => n.FindNearPoint(geoCodedPoints[0])).Returns(
                new List<Neighborhood>() {new Neighborhood() {Name = "FirstOne"}});
            fakeRepository.MockNeighborhoodRepository.Setup(n => n.FindNearPoint(geoCodedPoints[1])).Returns(
                new List<Neighborhood>() { new Neighborhood() { Name = "SecondOne" } });


            
            HomeController controller = new HomeController(fakeRepository, mockMapServer.Object);
            //HomeController.SearchCriteria criteria = new HomeController.SearchCriteria();
            //criteria.Address = address;

            // Act
            ViewResult result = controller.DisplaySearchResults(address) as ViewResult;

            var resultList = result.ViewData.Model as IList<Models.Neighborhood>;

            // Assert
            Assert.IsNotNull(resultList);
            Assert.AreEqual(2, resultList.Count);
            Assert.AreEqual("FirstOne", resultList[0].Name);
            Assert.AreEqual("SecondOne", resultList[1].Name);

        }

    }
}
