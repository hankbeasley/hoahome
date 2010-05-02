using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.ApplicationBlock;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth.ChannelElements;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.Extensions.OAuth;
using DotNetOpenAuth.OAuth.Messages;
using System.Web.Security;
using HOAHome.Models;
using HOAHome.Code.EntityFramework;

namespace HOAHome.Code.Google
{
    public class GoogleOAuth
    {
        private static OpenIdRelyingParty openid;// = new OpenIdRelyingParty();
        static readonly string GoogleOPIdentifier = "https://www.google.com/accounts/o8/id";
        static GoogleOAuth()
        {
            if (System.Web.HttpContext.Current != null)
            {
                openid = new OpenIdRelyingParty();
            }
        }
        public static ActionResult CreateGoogleAuthenticationAction()
        {
            //IAuthenticationRequest request = openid.CreateRequest(openidIdentifer);
            //var attRequest = new FetchRequest();
            //attRequest.Attributes.AddRequired(@"http://axschema.org/namePerson/first");
            //attRequest.Attributes.AddRequired(@"http://axschema.org/namePerson/last");

            //var oAuthRequest = new AuthorizationRequest();
            //oAuthRequest.Scope = GoogleConsumer.GetScopeUri(GoogleConsumer.Applications.Calendar | GoogleConsumer.Applications.Maps);
            //oAuthRequest.Consumer = "www.speedhq.com";

            //request.AddExtension(oAuthRequest);
            //request.AddExtension(attRequest);

            //return request.RedirectingResponse.AsActionResult();



            // Google requires that the realm and consumer key be equal,
            // so we constrain the realm to match the realm in the web.config file.
            // This does mean that the return_to URL must also fall under the key,
            // which means this sample will only work on a public web site
            // that is properly registered with Google.
            // We will customize the realm to use http or https based on what the
            // return_to URL will be (which will be this page).
            Realm realm = System.Web.HttpContext.Current.Request.Url.Scheme + Uri.SchemeDelimiter + Configuration.ConsumerKey + "/";
            //var userIdentifier = GoogleOPIdentifier;
            //Contract.Assume(userIdentifier != null);
           // Contract.Assume(openid.);
            IAuthenticationRequest authReq = openid.CreateRequest(GoogleOPIdentifier);
            
            // Prepare the OAuth extension
            string scope = GoogleConsumer.GetScopeUri(GoogleConsumer.Applications.Maps | GoogleConsumer.Applications.Calendar);
            MvcApplication.GoogleWebConsumer.AttachAuthorizationRequest(authReq, scope);

            // We also want the user's email address
            var fetch = new FetchRequest();
            fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
            fetch.Attributes.AddRequired(WellKnownAttributes.Name.First);
            fetch.Attributes.AddRequired(WellKnownAttributes.Name.Last);
            authReq.AddExtension(fetch);
            var response = authReq.RedirectingResponse;
            //Contract.Assume(response.ResponseStream != null);
            return response.AsActionResult();

        }

        public static IAuthenticationResponse GetResponse(){
            if (HttpContext.Current == null || HttpContext.Current.Request == null)
            {
                throw new ApplicationException("must run inside http context");
            }
            return openid.GetResponse();
        }

        public static AppUser HandleAuthenticationResponse(IAuthenticationResponse response, IPersistanceFramework persistance)
        {
            Contract.Requires(response != null);
            Contract.Requires(persistance != null);

            var attibuteExtension = response.GetExtension<FetchResponse>();
            var oAuth = response.GetExtension<AuthorizationApprovedResponse>();
            Contract.Assume(MvcApplication.GoogleWebConsumer.TokenManager is IOpenIdOAuthTokenManager);
            AuthorizedTokenResponse accessToken = MvcApplication.GoogleWebConsumer.ProcessUserAuthorization(response);

            if (accessToken == null)
            {
                throw new ApplicationException("User did not authorize access through google");
            }

            State.GoogleAccessToken = accessToken.AccessToken;
           
            AppUser claimedUser = new AppUser();
            claimedUser.AccessToken = accessToken.AccessToken;
            Contract.Assume(!string.IsNullOrEmpty(claimedUser.AccessToken));
            claimedUser.AccessTokenSecret = MvcApplication.GoogleTokenManager.GetTokenSecret(accessToken.AccessToken);
            claimedUser.GoogleId = response.ClaimedIdentifier;
            claimedUser.Email = attibuteExtension.Attributes[WellKnownAttributes.Contact.Email].Values.First();
            claimedUser.FirstName = attibuteExtension.Attributes[WellKnownAttributes.Name.First].Values.First();
            claimedUser.LastName = attibuteExtension.Attributes[WellKnownAttributes.Name.Last].Values.First();

            AppUser appUser = SyncUserWithHOAHome(claimedUser, persistance);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,appUser.Id.ToString(), DateTime.Now,DateTime.Now.AddDays(10), false, appUser.ToCookieString(), FormsAuthentication.FormsCookiePath);
            System.Web.HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));

            return appUser;
        }

        private static AppUser SyncUserWithHOAHome(AppUser claimedUser, IPersistanceFramework persistance)
        {
            Contract.Requires(claimedUser != null);
            Contract.Requires(persistance != null);
            var user = persistance.CreateQueryContext<AppUser>().Where(u => u.GoogleId == claimedUser.GoogleId).FirstOrDefault();
                if (user != null)
                {

                    user.LastLogin = DateTime.Now;
                    user.AccessToken = claimedUser.AccessToken;
                    user.AccessTokenSecret = claimedUser.AccessTokenSecret;
                    persistance.SaveChanges();
                    return user;
                }
                else
                {
                    claimedUser.LastLogin = DateTime.Now;
                    claimedUser.DisplayName = claimedUser.LastName + ", " + claimedUser.FirstName;
                    persistance.AttachNew(claimedUser);
                    persistance.SaveChanges();
                }
            
            return claimedUser;
        }
    }
}