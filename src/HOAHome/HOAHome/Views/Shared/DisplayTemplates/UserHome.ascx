<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HOAHome.Models.UserHome>" %>


    <fieldset style="float:left;width:300px;height:300px" >
        <%--<legend>Fields</legend>--%>
        
        <p>
            Name:
            <%= Html.Encode(Model.Name) %>
        </p>
        <p>
            Status:
            <%= Html.Encode(Model.RelationType) %>
        </p>
    </fieldset>
    
    <div id="MapDisplay" coordinates="<%= Model.Home.Latitude +"," + Model.Home.Longitude %>" style="float:right" ></div>
    
    <div style="clear:both">

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
   </div>


