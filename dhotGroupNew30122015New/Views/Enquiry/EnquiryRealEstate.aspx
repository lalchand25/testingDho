<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HomeMaster2.Master"
    Inherits="System.Web.Mvc.ViewPage<DhotGroupNew.Models.tb_EnquiryDhot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Enquiry
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
             <style type="text/css">
        input#FirstName
        {
            width: 200px;
        }
            input#EmailId
        {
            width: 200px;
        }
     
            input#ContactNo
        {
            width: 200px;
        }   
        
        
    </style>
    <form id="Form1" runat="server">
    <div id="box1">
        <h1>
            <% = ViewData["pageTitle"]  %>
        </h1>
        <div align="left">
            <% = ViewData["PageDesc"] %>
        </div>
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
                    <%: Html.EditorFor(model => model.ContactNo,  new { style = "width: 200px;Height:26px" }) %>
                    <%: Html.ValidationMessageFor(model => model.ContactNo) %>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <%=Html.DropDownList("EnquiryType", (SelectList)ViewData["typeData"], "Select", new { style = "width: 200px;Height:26px" })%>
                </td>
            </tr>
            <tr>
                <td>
                    <%: Html.LabelFor(model => model.Comments) %>
                </td>
                <td>
                         <%: Html.TextAreaFor(model => model.Comments, new { style = "width:200px; Height:60px" })%>
                    <%: Html.ValidationMessageFor(model => model.Comments) %>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload10" runat="server" class="multi" accept="doc|docx|xls|xlsx|png|jpg|gif" />
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
        <%--    <div>
            <%: Html.ActionLink("Back to List", "Index") %>
        </div>--%>
    </div>
    </form>
</asp:Content>
