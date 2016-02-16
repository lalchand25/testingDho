<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DhotGroupNew.Models.tb_ImagesDhot>" %>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
    type="text/javascript"></script>
<style type="text/css">
    input#Name
    {
        width: 300px;
    }
    input#Password
    {
        width: 200px;
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
            <fieldset>
                <br />
                <div class="editor-label">
                    Image Name
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.Name)%>
                    <%: Html.ValidationMessageFor(model => model.Name)%>
                </div>
                <div class="editor-field">
                    <asp:FileUpload ID="FileUpload10" runat="server" class="multi" accept="png|jpg|gif" />
                </div>
                <div>
                    Note: Logo size should be 997 x 350</div>
                <p>
                    <input style="margin: 5px 2px 0px 15px;" class="btn" name="" type="submit" value="Submit" />
                </p>
            </fieldset>
        </td>
    </tr>
</table>
<% } %>
<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>
</form>
