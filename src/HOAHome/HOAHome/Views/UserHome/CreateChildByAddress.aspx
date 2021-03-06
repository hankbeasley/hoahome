﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HOAHome.Models.UserHome>" %>
<%@ Import Namespace="HOAHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  Search for your home by entering its address below:
    
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm(MVC.UserHome.CreateChildByAddress((Guid)this.ViewData["parentId"]), FormMethod.Post))
       {%>
  
        <%=this.Html.Hidden("Name") %>
        <%=this.Html.Hidden("addressFull")%>
        <%=this.Html.Hidden("latitude") %>
        <%=this.Html.Hidden("longitude") %>        
    <% } %>
    <script type="text/javascript" >
        //configuration for map
        var allowName = true;
</script>
    <div id="map"></div>
    <div>
        <%=T4Extensions.ActionLink(Html, "Cancel", MVC.Account.Settings()) %>
    </div>
    
</asp:Content>
