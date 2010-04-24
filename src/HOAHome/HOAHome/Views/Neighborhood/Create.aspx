<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HOAHome.Models.Neighborhood>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create a New Nieghborhood
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>s
 <%using (this.Html.BeginForm())
      { %>
        <fieldset style="float:left">
        <legend>Nieghborhood Information</legend>
        <p>
        <%: this.Html.EditorCombo(c=> this.Model.Name) %> 
        <%= Html.Hidden("KML")%>
        </p>

    
    <div id="map"></div>
   
    </fieldset>
    
    <%} %>
    
</asp:Content>

