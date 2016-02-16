<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dhotGroup.Models.tb_EnquiryDhot>" %>
    <form id="Form1" runat="server">
<% using (Html.BeginForm())
   { %>
<%: Html.ValidationSummary(true) %>
<br />
<table>
    <tr>
        <td>
            Name
        </td>
        <td>
            <%: Html.EditorFor(model => model.FirstName) %>
            <%: Html.ValidationMessageFor(model => model.FirstName) %>
        </td>
    </tr>
    <tr>
        <td>
            Email
        </td>
        <td>
            <%: Html.EditorFor(model => model.EmailId) %>
            <%: Html.ValidationMessageFor(model => model.EmailId) %>
        </td>
    </tr>
    <tr>
        <td>
            Contact No
        </td>
        <td>
            <%: Html.EditorFor(model => model.ContactNo) %>
            <%: Html.ValidationMessageFor(model => model.ContactNo) %>
        </td>
    </tr>
    <tr>
        <td>
            <%: Html.LabelFor(model => model.Comments) %>
        </td>
        <td>
            <%: Html.EditorFor(model => model.Comments) %>
            <%: Html.ValidationMessageFor(model => model.Comments) %>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:FileUpload ID="FileUpload10" runat="server" class="multi" accept="png|jpg|gif" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <p>
                <input type="submit" value="Submit" />
            </p>
        </td>
    </tr>
</table>
<% } %>
</form>