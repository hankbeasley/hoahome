<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="HOAHome" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= HOAHome.Code.Security.Identity.Current.Name %></b>!
        [ <%= T4Extensions.ActionLink(Html, "Log Off", MVC.Account.LogOff()) %> ]
        [<%= T4Extensions.ActionLink(Html, "Settings", MVC.Account.Settings())%> ]
<%
    }
    else {
%> 
        [ <%= T4Extensions.ActionLink(Html, "Log On", MVC.Account.LogOn()) %> ]
<%
    }
%>
