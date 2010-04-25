<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<HOAHome.Models.Neighborhood>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DisplaySearchResults
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Address results</h2>
    <table style="display:inline;float:left">
        <tr><th>Address</th><th>Neighborhood</th><th></th></tr>
        <tr><td>11111 Ashcott Dr Houston TX 77072</td><td><%=this.Html.ActionLink("Brays Village", "Index", "Neighborhood") %> </td><td>Map It</td></tr>
        <tr><td>11111 Ashcott Dr Austin TX 77038</td><td>Start Neighborhood</td><td>Map It</td></tr>
         <% foreach (var item in Model)
            { %>
            <tr>
          <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td><%=this.Html.ActionLink("Brays Village", "Index", "Neighborhood") %> </td><td>Map It</td></tr>
         
         <%} %>
    
    </table>
    
    <div id="map" style="border-style:solid; border-width:2px;float:right;height:400px; width:300px">
    Map
   </div>
</asp:Content>
