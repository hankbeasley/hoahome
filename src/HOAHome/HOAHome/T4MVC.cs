﻿ 
 
// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[CompilerGenerated]
public static class MVC {
    public static HOAHome.Controllers.AccountController Account = new T4MVC_AccountController();
    public static HOAHome.Controllers.DirectorController Director = new T4MVC_DirectorController();
    public static HOAHome.Controllers.HomeController Home = new T4MVC_HomeController();
    public static HOAHome.Controllers.NeighborhoodController Neighborhood = new T4MVC_NeighborhoodController();
    public static HOAHome.Controllers.UserHomeController UserHome = new T4MVC_UserHomeController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}


namespace HOAHome.Controllers {
    public partial class AccountController {

        [CompilerGenerated]
        protected AccountController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }


        [CompilerGenerated]
        public readonly string Name = "Account";

        static readonly ActionNames s_actions = new ActionNames();
        [CompilerGenerated]
        public ActionNames Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class ActionNames {
            public readonly string LogOn = "LogOn";
            public readonly string Authenticate = "Authenticate";
            public readonly string LogOff = "LogOff";
            public readonly string Settings = "Settings";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
            public readonly string ChangePassword = "ChangePassword";
            public readonly string ChangePasswordSuccess = "ChangePasswordSuccess";
            public readonly string LogOn = "LogOn";
            public readonly string Register = "Register";
            public readonly string Settings = "Settings";
        }
    }
}
namespace HOAHome.Controllers {
    public partial class DirectorController {

        public DirectorController() { }

        [CompilerGenerated]
        protected DirectorController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }


        [CompilerGenerated]
        public readonly string Name = "Director";

        static readonly ActionNames s_actions = new ActionNames();
        [CompilerGenerated]
        public ActionNames Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class ActionNames {
            public readonly string Index = "Index";
            public readonly string Financals = "Financals";
            public readonly string Members = "Members";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
            public readonly string Financals = "Financals";
            public readonly string Members = "Members";
        }
    }
}
namespace HOAHome.Controllers {
    public partial class HomeController {

        public HomeController() { }

        [CompilerGenerated]
        protected HomeController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }


        [CompilerGenerated]
        public readonly string Name = "Home";

        static readonly ActionNames s_actions = new ActionNames();
        [CompilerGenerated]
        public ActionNames Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class ActionNames {
            public readonly string Index = "Index";
            public readonly string About = "About";
            public readonly string DisplaySearchResults = "DisplaySearchResults";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
            public readonly string About = "About";
            public readonly string DisplaySearchResults = "DisplaySearchResults";
            public readonly string Index = "Index";
        }
    }
}
namespace HOAHome.Controllers {
    public partial class NeighborhoodController {

        public NeighborhoodController() { }

        [CompilerGenerated]
        protected NeighborhoodController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }

        [NonAction]
        public ActionResult Locate() {
            return new T4MVC_ActionResult(Name, Actions.Locate);
        }

        [NonAction]
        public ActionResult Details() {
            return new T4MVC_ActionResult(Name, Actions.Details);
        }

        [NonAction]
        public ActionResult Edit() {
            return new T4MVC_ActionResult(Name, Actions.Edit);
        }

        [NonAction]
        public ActionResult Delete() {
            return new T4MVC_ActionResult(Name, Actions.Delete);
        }

        [NonAction]
        public ActionResult CreateChild() {
            return new T4MVC_ActionResult(Name, Actions.CreateChild);
        }


        [CompilerGenerated]
        public readonly string Name = "Neighborhood";

        static readonly ActionNames s_actions = new ActionNames();
        [CompilerGenerated]
        public ActionNames Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class ActionNames {
            public readonly string Create = "Create";
            public readonly string Locate = "Locate";
            public readonly string Details = "Details";
            public readonly string Edit = "Edit";
            public readonly string Delete = "Delete";
            public readonly string List = "List";
            public readonly string CreateChild = "CreateChild";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
            public readonly string Calendar = "Calendar";
            public readonly string Create = "Create";
            public readonly string Details = "Details";
            public readonly string Index = "Index";
            public readonly string List = "List";
        }
    }
}
namespace HOAHome.Controllers {
    public partial class UserHomeController {

        public UserHomeController() { }

        [CompilerGenerated]
        protected UserHomeController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }

        [NonAction]
        public ActionResult CreateChildByAddress() {
            return new T4MVC_ActionResult(Name, Actions.CreateChildByAddress);
        }

        [NonAction]
        public ActionResult Details() {
            return new T4MVC_ActionResult(Name, Actions.Details);
        }

        [NonAction]
        public ActionResult Edit() {
            return new T4MVC_ActionResult(Name, Actions.Edit);
        }

        [NonAction]
        public ActionResult Delete() {
            return new T4MVC_ActionResult(Name, Actions.Delete);
        }

        [NonAction]
        public ActionResult CreateChild() {
            return new T4MVC_ActionResult(Name, Actions.CreateChild);
        }


        [CompilerGenerated]
        public readonly string Name = "UserHome";

        static readonly ActionNames s_actions = new ActionNames();
        [CompilerGenerated]
        public ActionNames Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class ActionNames {
            public readonly string CreateChildByAddress = "CreateChildByAddress";
            public readonly string Details = "Details";
            public readonly string Create = "Create";
            public readonly string Edit = "Edit";
            public readonly string Delete = "Delete";
            public readonly string List = "List";
            public readonly string CreateChild = "CreateChild";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
            public readonly string CreateChildByAddress = "CreateChildByAddress";
            public readonly string Details = "Details";
            public readonly string Edit = "Edit";
        }
    }
}
namespace T4MVC {
    public class SharedController {


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
            public readonly string Error = "Error";
            public readonly string LogOnUserControl = "LogOnUserControl";
            static readonly _DisplayTemplates s_DisplayTemplates = new _DisplayTemplates();
            public _DisplayTemplates DisplayTemplates { get { return s_DisplayTemplates; } }
            public partial class _DisplayTemplates{
                public readonly string UserHome = "DisplayTemplates/UserHome";
            }
            static readonly _EditorTemplates s_EditorTemplates = new _EditorTemplates();
            public _EditorTemplates EditorTemplates { get { return s_EditorTemplates; } }
            public partial class _EditorTemplates{
                public readonly string UserHome = "EditorTemplates/UserHome";
            }
        }
    }
}

namespace T4MVC {
    [CompilerGenerated]
    public class T4MVC_AccountController: HOAHome.Controllers.AccountController {
        public T4MVC_AccountController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult LogOn() {
            var callInfo = new T4MVC_ActionResult("Account", Actions.LogOn);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Authenticate() {
            var callInfo = new T4MVC_ActionResult("Account", Actions.Authenticate);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult LogOff() {
            var callInfo = new T4MVC_ActionResult("Account", Actions.LogOff);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Settings() {
            var callInfo = new T4MVC_ActionResult("Account", Actions.Settings);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Settings(HOAHome.Models.AppUser toEdit) {
            var callInfo = new T4MVC_ActionResult("Account", Actions.Settings);
            callInfo.RouteValues.Add("toEdit", toEdit);
            return callInfo;
        }

    }
    [CompilerGenerated]
    public class T4MVC_DirectorController: HOAHome.Controllers.DirectorController {
        public T4MVC_DirectorController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult("Director", Actions.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Financals() {
            var callInfo = new T4MVC_ActionResult("Director", Actions.Financals);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Members() {
            var callInfo = new T4MVC_ActionResult("Director", Actions.Members);
            return callInfo;
        }

    }
    [CompilerGenerated]
    public class T4MVC_HomeController: HOAHome.Controllers.HomeController {
        public T4MVC_HomeController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult("Home", Actions.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult About() {
            var callInfo = new T4MVC_ActionResult("Home", Actions.About);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult DisplaySearchResults() {
            var callInfo = new T4MVC_ActionResult("Home", Actions.DisplaySearchResults);
            return callInfo;
        }

    }
    [CompilerGenerated]
    public class T4MVC_NeighborhoodController: HOAHome.Controllers.NeighborhoodController {
        public T4MVC_NeighborhoodController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Create(HOAHome.Models.Neighborhood entity) {
            var callInfo = new T4MVC_ActionResult("Neighborhood", Actions.Create);
            callInfo.RouteValues.Add("entity", entity);
            return callInfo;
        }

        public override System.Web.Mvc.ViewResult Locate(string searchString) {
            var callInfo = new T4MVC_ViewResult("Neighborhood", Actions.Locate);
            callInfo.RouteValues.Add("searchString", searchString);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Details(System.Guid id) {
            var callInfo = new T4MVC_ActionResult("Neighborhood", Actions.Details);
            callInfo.RouteValues.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Create() {
            var callInfo = new T4MVC_ActionResult("Neighborhood", Actions.Create);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(System.Guid id) {
            var callInfo = new T4MVC_ActionResult("Neighborhood", Actions.Edit);
            callInfo.RouteValues.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Delete(System.Guid id) {
            var callInfo = new T4MVC_ActionResult("Neighborhood", Actions.Delete);
            callInfo.RouteValues.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult List() {
            var callInfo = new T4MVC_ActionResult("Neighborhood", Actions.List);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(HOAHome.Models.Neighborhood entity) {
            var callInfo = new T4MVC_ActionResult("Neighborhood", Actions.Edit);
            callInfo.RouteValues.Add("entity", entity);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateChild(System.Guid parentId) {
            var callInfo = new T4MVC_ActionResult("Neighborhood", Actions.CreateChild);
            callInfo.RouteValues.Add("parentId", parentId);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateChild(System.Guid parentId, HOAHome.Models.Neighborhood entity) {
            var callInfo = new T4MVC_ActionResult("Neighborhood", Actions.CreateChild);
            callInfo.RouteValues.Add("parentId", parentId);
            callInfo.RouteValues.Add("entity", entity);
            return callInfo;
        }

    }
    [CompilerGenerated]
    public class T4MVC_UserHomeController: HOAHome.Controllers.UserHomeController {
        public T4MVC_UserHomeController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult CreateChildByAddress(System.Guid parentId) {
            var callInfo = new T4MVC_ActionResult("UserHome", Actions.CreateChildByAddress);
            callInfo.RouteValues.Add("parentId", parentId);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateChildByAddress(System.Guid parentId, HOAHome.Models.UserHome userHome, string addressFull, double latitude, double longitude) {
            var callInfo = new T4MVC_ActionResult("UserHome", Actions.CreateChildByAddress);
            callInfo.RouteValues.Add("parentId", parentId);
            callInfo.RouteValues.Add("userHome", userHome);
            callInfo.RouteValues.Add("addressFull", addressFull);
            callInfo.RouteValues.Add("latitude", latitude);
            callInfo.RouteValues.Add("longitude", longitude);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Details(System.Guid id) {
            var callInfo = new T4MVC_ActionResult("UserHome", Actions.Details);
            callInfo.RouteValues.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Create() {
            var callInfo = new T4MVC_ActionResult("UserHome", Actions.Create);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Create(HOAHome.Models.UserHome entity) {
            var callInfo = new T4MVC_ActionResult("UserHome", Actions.Create);
            callInfo.RouteValues.Add("entity", entity);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(System.Guid id) {
            var callInfo = new T4MVC_ActionResult("UserHome", Actions.Edit);
            callInfo.RouteValues.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Delete(System.Guid id) {
            var callInfo = new T4MVC_ActionResult("UserHome", Actions.Delete);
            callInfo.RouteValues.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult List() {
            var callInfo = new T4MVC_ActionResult("UserHome", Actions.List);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(HOAHome.Models.UserHome entity) {
            var callInfo = new T4MVC_ActionResult("UserHome", Actions.Edit);
            callInfo.RouteValues.Add("entity", entity);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateChild(System.Guid parentId) {
            var callInfo = new T4MVC_ActionResult("UserHome", Actions.CreateChild);
            callInfo.RouteValues.Add("parentId", parentId);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult CreateChild(System.Guid parentId, HOAHome.Models.UserHome entity) {
            var callInfo = new T4MVC_ActionResult("UserHome", Actions.CreateChild);
            callInfo.RouteValues.Add("parentId", parentId);
            callInfo.RouteValues.Add("entity", entity);
            return callInfo;
        }

    }

    [CompilerGenerated]
    public class Dummy {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}

namespace System.Web.Mvc {
    [CompilerGenerated]
    public static class T4Extensions {
        public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result) {
            return htmlHelper.RouteLink(linkText, result.GetRouteValueDictionary());
        }

        public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result, object htmlAttributes) {
            return ActionLink(htmlHelper, linkText, result, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result, IDictionary<string, object> htmlAttributes) {
            return htmlHelper.RouteLink(linkText, result.GetRouteValueDictionary(), htmlAttributes);
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod) {
            return htmlHelper.BeginForm(result, formMethod, null);
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod, object htmlAttributes) {
            return BeginForm(htmlHelper, result, formMethod, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod, IDictionary<string, object> htmlAttributes) {
            var callInfo = (IT4MVCActionResult)result;
            return htmlHelper.BeginForm(callInfo.Action, callInfo.Controller, callInfo.RouteValues, formMethod, htmlAttributes);
        }

        public static string Action(this UrlHelper urlHelper, ActionResult result) {
            return urlHelper.RouteUrl(result.GetRouteValueDictionary());
        }

        public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions);
        }

        public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions, object htmlAttributes) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions, htmlAttributes);
        }

        public static Route MapRoute(this RouteCollection routes, string name, string url, ActionResult result) {
            return routes.MapRoute(name, url, result, (ActionResult)null);
        }

        public static Route MapRoute(this RouteCollection routes, string name, string url, ActionResult result, object defaults) {
            // Start by adding the default values from the anonymous object (if any)
            var routeValues = new RouteValueDictionary(defaults);

            // Then add the Controller/Action names and the parameters from the call
            foreach (var pair in result.GetRouteValueDictionary()) {
                routeValues.Add(pair.Key, pair.Value);
            }

            // Create and add the route
            var route = new Route(url, routeValues, new MvcRouteHandler());
            routes.Add(name, route);
            return route;
        }

        public static RouteValueDictionary GetRouteValueDictionary(this ActionResult result) {
            return ((IT4MVCActionResult)result).RouteValues;
        }

        public static void InitMVCT4Result(this IT4MVCActionResult result, string controller, string action) {
            result.Controller = controller;
            result.Action = action; ;
            result.RouteValues = new RouteValueDictionary();
            result.RouteValues.Add("Controller", controller);
            result.RouteValues.Add("Action", action);
        }
    }
}

[CompilerGenerated]
public interface IT4MVCActionResult {
    string Action { get; set; }
    string Controller { get; set; }
    RouteValueDictionary RouteValues { get; set; }
}

[CompilerGenerated]
public class T4MVC_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult {
    public T4MVC_ActionResult(string controller, string action): base()  {
        this.InitMVCT4Result(controller, action);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public RouteValueDictionary RouteValues { get; set; }
}

[CompilerGenerated]
public class T4MVC_ViewResult : System.Web.Mvc.ViewResult, IT4MVCActionResult {
    public T4MVC_ViewResult(string controller, string action): base()  {
        this.InitMVCT4Result(controller, action);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public RouteValueDictionary RouteValues { get; set; }
}


namespace Links {
    [CompilerGenerated]
    public static class @Scripts {
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Scripts"); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Scripts/" + fileName); }
        public static readonly string jquery_1_3_2_vsdoc_js = Url("jquery-1.3.2-vsdoc.js");
        public static readonly string jquery_1_3_2_js = Url("jquery-1.3.2.js");
        public static readonly string jquery_1_3_2_min_js = Url("jquery-1.3.2.min.js");
        public static readonly string jquery_validate_vsdoc_js = Url("jquery.validate-vsdoc.js");
        public static readonly string jquery_validate_js = Url("jquery.validate.js");
        public static readonly string jquery_validate_min_js = Url("jquery.validate.min.js");
        public static readonly string MicrosoftAjax_debug_js = Url("MicrosoftAjax.debug.js");
        public static readonly string MicrosoftAjax_js = Url("MicrosoftAjax.js");
        public static readonly string MicrosoftMvcAjax_debug_js = Url("MicrosoftMvcAjax.debug.js");
        public static readonly string MicrosoftMvcAjax_js = Url("MicrosoftMvcAjax.js");
        public static readonly string MicrosoftMvcJQueryValidation_js = Url("MicrosoftMvcJQueryValidation.js");
    }

    [CompilerGenerated]
    public static class @Content {
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content"); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/" + fileName); }
        public static readonly string anylinkcssmenu_css = Url("anylinkcssmenu.css");
        public static readonly string anylinkcssmenu_js = Url("anylinkcssmenu.js");
        public static readonly string Site_css = Url("Site.css");
    }

}

static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    public static string ProcessVirtualPath(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }
}


#endregion T4MVC
#pragma warning restore 1591

