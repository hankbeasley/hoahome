<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HOAHome.Models.UserHome>" %>
<%@ Import Namespace="HOAHome.Code.Mvc" %>
        <fieldset>
            <%: Html.EditorCombo(c=>c.Name) %>
        </fieldset>
