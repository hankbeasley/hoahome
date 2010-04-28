using System;
using System.Collections.Generic;
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
            var bundle = (ContentBundle)htmlHelper.ViewData[ViewDataKey];
            return string.Format(cmsbinding, string.Join(",",bundle.GetIds().Select(b=>b.ToString())));
        }
    }
}