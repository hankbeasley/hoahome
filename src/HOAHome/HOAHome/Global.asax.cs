using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using DotNetOpenAuth.OAuth;
using HOAHome.Code;
using DotNetOpenAuth.ApplicationBlock;
using System.Web.Security;
using HOAHome.Code.Security;
using HOAHome.Models;

namespace HOAHome
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        internal static WebConsumer GoogleWebConsumer
        {
            get
            {
                var googleWebConsumer = (WebConsumer)HttpContext.Current.Application["GoogleWebConsumer"];
                if (googleWebConsumer == null)
                {
                    googleWebConsumer = new WebConsumer(GoogleConsumer.ServiceDescription, GoogleTokenManager);
                    HttpContext.Current.Application["GoogleWebConsumer"] = googleWebConsumer;
                }

                return googleWebConsumer;
            }
        }

        internal static InMemoryTokenManager GoogleTokenManager
        {
            get
            {
                var tokenManager = (InMemoryTokenManager)HttpContext.Current.Application["GoogleTokenManager"];
                if (tokenManager == null)
                {
                    string consumerKey = "www.speedhq.com";
                    string consumerSecret = "94EDK/uw3X/Pls4yARJrCrG6";
                    if (!string.IsNullOrEmpty(consumerKey))
                    {
                        tokenManager = new InMemoryTokenManager(consumerKey, consumerSecret);
                        HttpContext.Current.Application["GoogleTokenManager"] = tokenManager;
                    }
                }

                return tokenManager;
            }
        }

        protected void Application_AuthenticateRequest()
        {
           
        }
        
    }
}