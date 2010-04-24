﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HOAHome.Models.UserHome>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  Search for your home by entering its address below:
    
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm())
       {%>
  
        <%=this.Html.Hidden("Name") %>
        <%=this.Html.Hidden("addressFull")%>
        <%=this.Html.Hidden("Latitude") %>
        <%=this.Html.Hidden("Longitude") %>        
    <% } %>
    <div id="map"></div>
    <div>
        <%=Html.ActionLink("Cancel", MVC.Account.Settings()) %>
    </div>
    
</asp:Content>