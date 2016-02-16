<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/profileMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<DhotGroupNew.Models.tb_PageDescription>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../jscripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../jscripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">


        function UpdateTaskList() {
            destElement = document.getElementById("contacttypeid");

            id = destElement.value

            var url = '/Contacts/contactlist/' + id;

            $("#tasklistResult").load(url);



        }

 


    </script>
    <div id="box3">
        <h1>
            Application Pages</h1>
        <br />
        <div align="right">
            <a href="/pages/create">
                <img src="../../SiteImages/addnew.png" />
            </a>
        </div>
        <table class="border" width="100%">
            <tr>
                <th>
                    Page Name / Order Id
                </th>
                <th>
                    Title
                </th>
                <th>
                    Edit
                </th>
            </tr>
            <% foreach (var item in Model)
               { %>
            <tr>
                <td>
                    <%: item.PageName  %>/<%=item.SetModuleID %>
                </td>
                <td>
                    <%: item.Title %>
                </td>
                <td>
                    <br />
                    <a href="<%= Url.Action("Edit", "Pages",new {id=item.Pageid})%>">
                        <img src="<%=Url.Content("~/SiteImages/edit.png") %>" border="0" alt="edit" /></a>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
</asp:Content>
