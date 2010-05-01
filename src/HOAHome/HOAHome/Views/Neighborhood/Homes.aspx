<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IEnumerable<HOAHome.Models.Home>>" MasterPageFile="~/Views/Shared/NeighborHood.Master" %>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="NeighborhoodTitle"></asp:Content>
<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">
  <% foreach (var item in Model) { %>
    
        <%= this.Html.DisplayFor(f=>item) %>
    
    <% } %>
    <%= this.Html.IfAdmin(()=>this.Html.ActionLink("Add new", MVC.Neighborhood.AddHome())) %>
</asp:Content>

