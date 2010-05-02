using System.Diagnostics.Contracts;
using System.Web.Mvc;

namespace HOAHome.Areas.nh
{
    public class nhAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "nh";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            Contract.Assume(context != null);

            context.MapRoute(
                "nh_default",
                "nh/{nhid}/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
