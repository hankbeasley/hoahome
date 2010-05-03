<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HOAHome.Models.Neighborhood>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create a New Nieghborhood
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
<%
    Html.EnableClientValidation(); %>
 <%using (this.Html.BeginForm())
      { %>
        <fieldset style="float:left">
        <legend>Nieghborhood Information</legend>
        <p>
        <%= this.Html.EditorCombo(c=> c.Name) %> 
        <%= this.Html.HiddenFor(c=>c.KML) %>
        <%= this.Html.HiddenFor(c=>c.Location) %>
        </p>

    
    <div id="map"></div>
   
    </fieldset>
    
    <%} %>
    
</asp:Content>

