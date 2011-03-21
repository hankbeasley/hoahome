using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.Extensions.OAuth;
using DotNetOpenAuth.OAuth.Messages;
using HOAHome.Code;
using DotNetOpenAuth.ApplicationBlock;
using HOAHome.Code.Google;
using HOAHome.Models;
using HOAHome.Code.Security;
using HOAHome.Code.Mvc;
using HOAHome.Code.EntityFramework;
namespace HOAHome.Controllers
{

    [HandleError]
    public partial class AccountController : Controller, IPersistanceContainer
    {
        private readonly IPersistanceFramework entities = new PersistanceFramework( new COHHomeEntities());

        public AccountController()
           
        {
        }

        public virtual ActionResult LogOn()
        {
            return View("LogOnRazor");
        }
       
        [ValidateInput(false)]
        public virtual ActionResult Authenticate()
        {
            Contract.Assume(this.ViewData != null);

            var response = GoogleOAuth.GetResponse(); 
            if (response == null)
            {
                // Stage 2:
                
                    try
                    {
                        return GoogleOAuth.CreateGoogleAuthenticationAction();
                    }
                    catch (ProtocolException ex)
                    {
                        ViewData["Message"] = ex.Message;
                        return View("LogOnRazor");
                    }
                
            }
            else
            {
                // Stage 3: OpenID Provider sending assertion response
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        Contract.Assume(entities != null);
                        GoogleOAuth.HandleAuthenticationResponse(response, entities);

                        return RedirectToAction("Index", "Home");
                    case AuthenticationStatus.Canceled:
                        ViewData["Message"] = "Canceled at provider";
                        return View("LogOn");
                    case AuthenticationStatus.Failed:
                        ViewData["Message"] = response.Exception.Message;
                        return View("LogOn");
                }
            }
            return new EmptyResult();
        }

        public virtual ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return View("LogOn");
        }
        public virtual ActionResult Settings()
        {
            //this.ViewData.Model = entities.Get<AppUser>(Identity.Current.Id);
            //    ((AppUser)this.ViewData.Model).UserHomes.Load(;
            //    return View();
            var user = entities.CreateQueryContext<AppUser>("UserHomes", "UserHomes.Home").Where(a => a.Id == Identity.Current.Id).Single();
            this.ViewData.Model = user;
            return this.View();
            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Settings(AppUser toEdit)
        {
            entities.SaveChanges();
            this.ViewData.Model = toEdit;
            return this.View();
        }
        object IPersistanceContainer.Load(Guid Id)
        {
            return entities.Get<AppUser>(Identity.Current.Id);
        }
    }
}
