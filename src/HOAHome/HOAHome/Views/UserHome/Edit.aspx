﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HOAHome.Models.UserHome>" %>
<%@ Import Namespace="HOAHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <%: this.Html.EditorForModel() %>

    

    <div>
         <input type="submit" value="save" />
        <%=Html.ActionLink("Delete", MVC.UserHome.Delete(this.Model.Id)) %>
    </div>
    <% } %>
</asp:Content>

