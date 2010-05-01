<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HOAHome.Models.Home>" %>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">AddressLine1</div>
        <div class="display-field"><%: Model.AddressLine1 %></div>
        
        <div class="display-label">AddressLine2</div>
        <div class="display-field"><%: Model.AddressLine2 %></div>
        
        <div class="display-label">City</div>
        <div class="display-field"><%: Model.City %></div>
        
        <div class="display-label">State</div>
        <div class="display-field"><%: Model.State %></div>
        
        <div class="display-label">Zip</div>
        <div class="display-field"><%: Model.Zip %></div>
        
        <div class="display-label">AddressFull</div>
        <div class="display-field"><%: Model.AddressFull %></div>
        
        <div class="display-label">GoogleFeatureId</div>
        <div class="display-field"><%: Model.GoogleFeatureId %></div>
        
        <div class="display-label">Latitude</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Latitude) %></div>
        
        <div class="display-label">Longitude</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Longitude) %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>


