using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.GData.Client;

namespace HOAHome.Code
{
    public class OAuthRequestFactory : GDataGAuthRequestFactory
    {
        public OAuthRequestFactory(string service, string applicationName) : base(service, applicationName) { }
        public override IGDataRequest CreateRequest(GDataRequestType type, Uri uriTarget)
        {
            return new OAuthRequest(type, uriTarget, this);
        }


        //////////////////////////////////////////////////////////////////////
        /// <summary>accessor method public string ConsumerSecret</summary> 
        /// <returns>the ConsumerSecret for the oauth request </returns>
        //////////////////////////////////////////////////////////////////////
        public string ConsumerSecret
        {
            get;
            set;
        }
        // end of accessor public string ConsumerSecret

        //////////////////////////////////////////////////////////////////////
        /// <summary>accessor method public string ConsumerKey</summary> 
        /// <returns>the ConsumerKey used for the oauth request </returns>
        //////////////////////////////////////////////////////////////////////
        public string ConsumerKey
        {
            get;
            set;
        }

        public string AccessToken
        {
            get;
            set;
        }
    }
}