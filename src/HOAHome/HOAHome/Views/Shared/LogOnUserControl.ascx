<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= HOAHome.Code.Security.Identity.Current.Name %></b>!
        [ <%= Html.ActionLink("Log Off", "LogOff", "Account") %> ]
        [<%= Html.ActionLink("Settings", "Settings", "Account")%> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Log On", "LogOn", "Account") %> ]
<%
    }
%>
