using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Models;

namespace HOAHome.Code.ContentManagement
{
    public static class HtmlHelperExtensions
    {
        private static string htmlElement = @"<div id=""{0}"">{1}</div>";
        private static readonly string ViewDataKey = typeof (ContentBundle).Name;
        public static string Cms(this HtmlHelper htmlHelper, ContentType contentType)
        {
            var bundle = (ContentBundle)htmlHelper.ViewData[ViewDataKey];
            return string.Format(htmlElement, contentType.Id, bundle.GetContent(contentType.Id));
        }

        private static string cmsbinding = @"<script>var cmsIds=""{0}"";</script>";
        public static string CmsEditorBinding(this HtmlHelper htmlHelper)
        {
            Contract.Requires(htmlHelper.ViewContext.RouteData != null );
            Contract.Requires(htmlHelper.ViewContext.RouteData.Values["nhid"] != null);
            

            Guid nhid = new Guid((String) htmlHelper.ViewContext.RouteData.Values["nhid"]);
            bool isAdmin = htmlHelper.ViewContext.HttpContext.User.Identity.IsAuthenticated &&
                Code.Security.Principal.IsUserInNeighborhoodRole(Code.Security.Identity.Current.Id, nhid,
                                                                            Role.Administrator.Id);
            var bundle = (ContentBundle)htmlHelper.ViewData[ViewDataKey];
           // Contract.Assume(bundle != null);
            //var strArrayIds2 = bundle.GetIds();
            //var strArrayIds =;
            //Contract.Assume(strArrayIds != null);
            string ids = string.Join(",",  bundle.GetIds().Select(b => b.ToString()));
            if (!isAdmin)
            {
                ids = string.Empty;
            }
            return string.Format(cmsbinding, ids);
        }

        [ContractInvariantMethod]
        static void ObjectInvariant() { Contract.Invariant(ViewDataKey !=null); }
    }
}