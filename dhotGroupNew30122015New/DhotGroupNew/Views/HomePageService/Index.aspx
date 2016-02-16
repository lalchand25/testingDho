<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProfileMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<DhotGroupNew.Models.tb_HomePageServicesDhot>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="box3">
        <h1>
            Service List</h1>
        <br />
        <div align="right">
            <a href="/HomePageService/create">
                <img src="../../SiteImages/addnew.png" />
            </a>
        </div>
        <table class="border" width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <th>
                    Heading
                </th>
                <th>
                    Description
                </th>
                <th>
                    ImagePath
                </th>
                <th>
                    urllink
                </th>
                <th>
                    Edit
                </th>
            </tr>
            <tr>
                <td width="20%">
                </td>
                <td width="20%">
                </td>
                <td width="20%">
                </td>
                <td width="20%">
                </td>
                  <td width="20%">
                </td>
            </tr>
            <% foreach (var item in Model)
               { %>
            <tr>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Heading) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Description) %>
                </td>
               
                <td>
                    <%: Html.DisplayFor(modelItem => item.ImagePath) %>
                </td>
                 <td>
                    <%: Html.DisplayFor(modelItem => item.urllink) %>
                </td>
                <td>
                    <a href="<%= Url.Action("Edit", "HomePageService",new {id=item.AutoID})%>">
                        <img src="<%=Url.Content("~/SiteImages/edit.png") %>" border="0" alt="edit" /></a>
                    <%--                   <%: Html.ActionLink("Edit", "Edit", new { id=item.AutoID }) %>
                    |
                    <%: Html.ActionLink("Delete", "Delete", new { id=item.AutoID }) %>--%>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
</asp:Content>
