<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/NeighborHood.Master" Inherits="System.Web.Mvc.ViewPage" ValidateRequest="false" %>
<asp:Content ContentPlaceHolderID="NeighborhoodTitle" runat="server">
Brays Village
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <%=this.Html.Cms(HOAHome.Models.ContentType.HomePageMain) %>
    <%=this.Html.CmsEditorBinding() %>
</asp:Content>

