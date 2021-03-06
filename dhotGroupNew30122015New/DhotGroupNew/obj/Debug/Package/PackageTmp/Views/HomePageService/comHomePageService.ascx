﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DhotGroupNew.Models.tb_HomePageServicesDhot>" %>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
    type="text/javascript"></script>
<style type="text/css">
    input#Heading
    {
        width: 350px;
    }
    input#Password
    {
        width: 200px;
    }
       input#urllink
    {
        width: 350px;
    }
    
    
</style>
<form id="Form1" runat="server">
<% using (Html.BeginForm())
   { %>
<%: Html.ValidationSummary(true) %>
<table>
    <tr>
        <td width="30%">
        </td>
        <td width="70%">
        </td>
    </tr>
    <tr>
        <td>
            <%: Html.LabelFor(model => model.Heading) %>
        </td>
        <td>
            <%: Html.EditorFor(model => model.Heading) %>
            <%: Html.ValidationMessageFor(model => model.Heading) %>
        </td>
    </tr>
    <tr>
        <td>
            <%: Html.LabelFor(model => model.Description) %>
        </td>
        <td>
            <%: Html.TextAreaFor(model => model.Description, new { style = "width: 350px; height: 175px;" })%>
            <%: Html.ValidationMessageFor(model => model.Description) %>
        </td>
    </tr>
    <tr>
        <td>
         URL
        </td>
        <td>
            <%: Html.EditorFor(model => model.urllink) %>
            <%: Html.ValidationMessageFor(model => model.urllink) %>
        </td>
    </tr>
    <tr>
        <td>
            Image
        </td>
        <td>
            <asp:FileUpload ID="FileUpload10" runat="server" class="multi" accept="png|jpg|gif" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <input style="margin: 5px 2px 0px 15px;" class="btn" name="" type="submit" value="Submit" />
        </td>
    </tr>
</table>
<% } %>
<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>
</form>
