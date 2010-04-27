<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<HOAHome.Models.Neighborhood>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DisplaySearchResults
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Address results</h2>
    <table style="display:inline;float:left">
        <tr><th>Address</th><th>Neighborhood</th><th></th></tr>
        <% foreach (var item in Model)
            { %>
            <tr><td><%= Html.Encode(item.Name) %></td><td><%=this.Html.ActionLink(item.Name, "Index", "Neighborhood", new{nhid=item.Id}, null) %> </td><td>Map It</td></tr>
         <%} %>
    
    </table>
    
    <div id="map" style="border-style:solid; border-width:2px;float:right;height:400px; width:300px">
    Map
   </div>
</asp:Content>
