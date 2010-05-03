<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HOAHome.Models.Neighborhood>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%--    <h2>List</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                PrimaryContactId
            </th>
            <th>
                KML
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", MVC.Neighborhood.Edit(item.Id)) %> |
                <%= Html.ActionLink("Details", MVC.Neighborhood.Edit(item.Id)) %>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.PrimaryContactId) %>
            </td>
            <td>
                <%= Html.Encode(item.KML) %>
            </td>
        </tr>
    
    <% } %>
      </table>
    --%>
  
    <% =this.Html.Grid(Model).Columns(c => { 
        c.For(x => Html.ActionLink("Edit", MVC.Neighborhood.Edit(x.Id))).DoNotEncode();
        c.For(x => Html.ActionLink("Details", MVC.Neighborhood.Details(x.Id))).DoNotEncode();
        c.For(x => Html.ActionLink("View Site", MVC.nh.Neighborhood.Index().AddRouteValue("nhid",x.Id))).DoNotEncode();
        c.For(x => x.Name); })%>
    

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

