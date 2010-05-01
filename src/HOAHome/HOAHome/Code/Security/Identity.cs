using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Security.Principal;
using HOAHome.Models;
using System.Web.Security;

namespace HOAHome.Code.Security
{
    [Serializable]
    public class Identity : IIdentity
    {
        public string AuthenticationType
        {
            get { return "Google"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        private readonly AppUser appUser;
        public string Name
        {
            get { return this.appUser.DisplayName; }
        }

        public Guid Id
        {
            get
            {
                return this.appUser.Id;
            }
        }

        public Identity(AppUser appUser)
        {
            Contract.Requires(appUser !=null);
            this.appUser = appUser;
        }

        public static Identity Current
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return new Identity(TestingAppUser);
                }
                var formsCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (formsCookie != null){
                    
                    
                        string cookieValue = formsCookie.Value;
                        var ticket = FormsAuthentication.Decrypt(cookieValue);
                        Contract.Assume(ticket.Name != null);
                        var identity = new Identity(AppUser.FromCookieString(new Guid(ticket.Name), ticket.UserData));
                        return identity;
                    
                }
                return null;

            }
        }
        private static AppUser TestingAppUser = new AppUser() { Id = Guid.NewGuid(), DisplayName = "testUser" };


        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.appUser != null);
            //Contract. Invariant ( this .x > this.y );


        }
    }
}