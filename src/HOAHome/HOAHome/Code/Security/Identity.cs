using System;
using System.Collections.Generic;
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

        private AppUser appUser; 
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

                if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null){
                    
                        string cookieValue = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                        var ticket = FormsAuthentication.Decrypt(cookieValue);
                        var identity = new Identity(AppUser.FromCookieString(new Guid(ticket.Name), ticket.UserData));
                        return identity;
                    
                }
                return null;

            }
        }
        private static AppUser TestingAppUser = new AppUser() { Id = Guid.NewGuid(), DisplayName = "testUser" };
    }
}