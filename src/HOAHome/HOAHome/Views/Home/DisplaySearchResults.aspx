<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<HOAHome.Models.Neighborhood>>" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Nieghborhood Search Results
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Neighborhood Results</h2>
   <%-- <table style="display:inline;float:left">
        <tr><th>Address</th><th>Neighborhood</th><th></th></tr>
        <% foreach (var item in Model)
            { %>
            <tr><td><%=this.Html.ActionLink(item.Name, MVC.nh.Neighborhood.Index().AddRouteValue("nhid",item.Id)) %></td><td>Map It</td></tr>
         <%} %>
    
    </table>--%>
    
    <%=this.Html.Grid(this.Model).
         Columns(c =>
                     {
                         c.For(
                             x => this.Html.ActionLink(x.Name, MVC.nh.Neighborhood.Index().AddRouteValue("nhid", x.Id)))
                             .DoNotEncode().Named("Neighborhood");
                         c.For(x => x.Location);
                     })
     %>

    <div id="map" style="border-style:solid; border-width:2px;float:right;height:400px; width:300px">
    Map
   </div>
</asp:Content>
