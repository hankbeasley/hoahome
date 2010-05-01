using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Models;

namespace HOAHome.Code.Mvc
{
    public class NeighborhoodRoleAttribute : AuthorizeAttribute
    {
        
        public String NeighborhoodRoleName { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
           
            if (!base.AuthorizeCore(httpContext))
            {
                return false;
            }
            Guid roleId = Guid.Empty;
            if (this.NeighborhoodRoleName == Role.Administrator.Name)
            {
                roleId = Role.Administrator.Id;
            }
            //var nhid = httpContext.Items["nhid"];
            if (httpContext.Items["nhid"] == null) throw new InvalidOperationException("context must contain nhid");
            Guid neighborhoodId = new Guid((String)httpContext.Items["nhid"]);
            bool isInNeighborhood = Code.Security.Principal.IsUserInNeighborhoodRole(Code.Security.Identity.Current.Id, neighborhoodId,
                                                                    roleId);
            return isInNeighborhood;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Items["nhid"] = filterContext.RouteData.Values["nhid"];
            base.OnAuthorization(filterContext);
        }
    }
}