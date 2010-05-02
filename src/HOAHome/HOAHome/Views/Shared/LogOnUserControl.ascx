<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= HOAHome.Code.Security.Identity.Current.Name %></b>!
        [ <%= Html.ActionLink("Log Off", MVC.Account.LogOff()) %> ]
        [<%= Html.ActionLink("Settings", MVC.Account.Settings())%> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Log On", MVC.Account.LogOn()) %> ]
<%
    }
%>
