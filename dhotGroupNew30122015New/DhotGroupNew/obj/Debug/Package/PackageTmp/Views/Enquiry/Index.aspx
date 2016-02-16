<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/profileMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<DhotGroupNew.Models.tb_ContactUs>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div class="main_frame_right">
        <h1>
            Contact List
        </h1>
   
            <table class="border" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <th>
                        Email ID
                    </th>
                    <th>
                        First Name
                    </th>
                    <th>
                        Last Name
                    </th>
                    <th>
                        Contact No
                    </th>
                    <th>
                        Comments
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
                        <%: Html.DisplayFor(modelItem => item.EmailId) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.FirstName) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.LastName) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.ContactNo) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.Comments) %>
                    </td>
                  
                </tr>
                <% } %>
            </table>
     
    </div>
</asp:Content>
