<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HOAHome.Models.Neighborhood>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <%=this.Html.DisplayForModel() %>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", MVC.Neighborhood.Edit(Model.Id)) %> |
        <%=Html.ActionLink("Back to List", "List") %>
    </p>

</asp:Content>


