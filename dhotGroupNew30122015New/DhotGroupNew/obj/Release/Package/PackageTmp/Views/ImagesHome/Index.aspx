<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProfileMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<DhotGroupNew.Models.tb_ImagesHomeDhot>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div id="box3">
        <h1>
             Images List
        </h1>
        <div class="main_frame_right_box">
            <p>
                <a href="/ImagesHome/create">
                    <img src="../../SiteImages/addnew.png" />
                </a>
            </p>
             <div class="scrolldiv3"> 

            <table class="border" width="100%">
                <tr>
                    <th>
                        Image
                    </th>
                    <th>
                        Name
                    </th>
                
                    <th>
                        Edit
                    </th>
              <%--      <th>
                        Delete
                    </th>--%>
                </tr>
                <tr>
                    <td width="20%">
                    </td>
                    <td width="60%">
                    </td>
                 
                    <td width="10%">
                    </td>
                <%--    <td width="10%">
                    </td>--%>
                </tr>
                <% foreach (var item in Model)
                   { %>
                <tr>
                    <td>
                        <img src="/uploads/<%: Html.DisplayFor(modelItem => item.ImagePath) %>" width="100px"
                            height="80px" alt="Image" />
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.Name) %>
                    </td>
                 
                    <td>
                        <a href="<%= Url.Action("Edit", "ImagesHome", new { id=item.ImageID })%>">
                            <img src="<%=Url.Content("~/SiteImages/edit.png") %>" border="0" alt="edit" /></a>
                    </td>
                 <%--   <td>
                        <a href="<%= Url.Action("Delete", "ImagesHome", new { id=item.ImageID })%>">
                            <img src="<%=Url.Content("~/SiteImages/delete.png") %>" border="0" alt="edit" /></a>
                    </td>--%>
                    </tr>
                    <% } %>
            </table>
            </div>

        </div>
    </div>
</asp:Content>
