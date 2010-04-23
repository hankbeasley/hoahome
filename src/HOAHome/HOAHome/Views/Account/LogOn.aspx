<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["Message"]%>
    
    Please log in through google
   
    
    <% using (Html.BeginForm(MVC.Account.Authenticate()))
       { %>
            <input type="submit" value="Login through google" />
    <% }%>
    
</asp:Content>
