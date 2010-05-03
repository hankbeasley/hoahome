<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/NeighborHood.Master" %>
<asp:Content runat="server" ID="Content" ContentPlaceHolderID="MainContent">

 Search for your home by entering its address below:
    
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm())
       {%>
        <%=this.Html.Hidden("addressFull")%>
        <%=this.Html.Hidden("latitude") %>
        <%=this.Html.Hidden("longitude") %>        
    <% } %>
    <div id="map"></div>
<script type="text/javascript" >
    //configuration for map
    var allowName = false;
</script>
</asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="NeighborhoodTitle"></asp:Content>
