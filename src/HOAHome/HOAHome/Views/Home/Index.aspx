<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
   
   <% using (Html.BeginForm("DisplaySearchResults", "Home"))
      { %>
        <fieldset style="width:260px;float:left">
         <legend>Find a Neighborhood</legend>
            <p>
                <label for="address">Address:</label> <%= Html.TextBox("address")%>
            </p>
            <p>
                <input type="submit" value="Search" />
             </p>
        </fieldset>
   
   
   <div id="map" style="border-style:solid; border-width:2px;float:left;" > </div>
   
   <%} %>
</asp:Content>
