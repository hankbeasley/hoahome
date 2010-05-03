// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace HOAHome.Areas.nh.Controllers {
    public partial class NeighborhoodController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected NeighborhoodController(Dummy d):this() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public NeighborhoodController Actions { get { return MVC.nh.Neighborhood; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "nh";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Neighborhood";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string TitlePartial = "TitlePartial";
        }


        static readonly ViewNames s_views = new ViewNames();
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Index = "~/Areas/nh/Views/Neighborhood/Index.aspx";
            public readonly string TitlePartial = "~/Areas/nh/Views/Neighborhood/TitlePartial.ascx";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_NeighborhoodController: HOAHome.Areas.nh.Controllers.NeighborhoodController {
        public T4MVC_NeighborhoodController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ViewResult Index() {
            var callInfo = new T4MVC_ViewResult(Area, Name, ActionNames.Index);
            return callInfo;
        }

        public override System.Web.Mvc.PartialViewResult TitlePartial() {
            var callInfo = new T4MVC_PartialViewResult(Area, Name, ActionNames.TitlePartial);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
