<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AppUser>" %>
<%@ Import Namespace="HOAHome.Models" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>
<%@ Import Namespace="HOAHome" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Settings
</asp:Content>
<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
     <% using (Html.BeginForm())
        { %>
    <fieldset style="float:left">
        <legend>Account Information</legend>
        <p>
            <%: Html.EditorCombo(c=>c.DisplayName) %>
        </p>
        <p>
            <%: Html.EditorCombo(c=>c.FirstName) %>
        </p>
        <p>
            <%: Html.EditorCombo(c=>c.LastName) %>
        </p>
        
         <input type="submit" value="save" />
    </fieldset>
       
        <%= Html.HiddenFor(c=>c.Id)%>
     
      <fieldset style="float:left">
        <legend>Homes</legend>
     <%=this.Html.Grid(this.Model.UserHomes).
         Columns(c => { c.For(x => Html.ActionLink(x.Name, MVC.UserHome.Details(x.Id))).DoNotEncode();
         c.For(x => x.Home.AddressFull).Named("Address");
         })
              %>
              <p>
     <%=this.Html.ActionLink("Add home",MVC.UserHome.CreateChildByAddress(this.Model.Id)) %>
     </p>
     </fieldset>
     <% } %>
</asp:Content>
