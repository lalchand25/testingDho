<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProfileMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<DhotGroupNew.Models.tb_EnquiryDhot>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EnquiryList
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="box3">
        <h1>
            Enquiry List</h1>
        <br />
       <table class="border" width="100%">
            <tr>
               
                <th>
                    Name
                </th>
              
              <th>
                    Email Id
                </th>
                <th>
                    Contact No
                </th>
                <th>
                    Comments
                </th>
             
              <th> Date & Time</th>
                <th>
                    Download
                </th>
                 <th> Delete </th>
            </tr>
            <% foreach (var item in Model)
               { %>
            <tr>
               
                <td>
                    <%: Html.DisplayFor(modelItem => item.FirstName) %>
                </td>
              
             <td>
                    <%: Html.DisplayFor(modelItem => item.EmailId) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.ContactNo) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Comments) %>
                </td>

                   <td width="11%">
                    <%: Html.DisplayFor(modelItem => item.SystemDate) %>
                </td>

                <% if (item.filepath != null && item.filepath != "")
                   {   %>
                <td>
                 <a href="../../uploads/<%=item.filepath%>" target='_blank' /> <img src='../../images/Download.png' />  
               
              
                   
                      </td>
                    <%}
                   else
                   { %>
                   <td> </td>
              <%} %>

                <td>
   <%--         <%: Html.ActionLink("Edit", "Edit", new { id=item.ID }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.ID }) %> |--%>

<%--            <%: Html.ActionLink("Delete", "Delete", new { id=item.ID }) %>--%>

               <a href="<%= Url.Action("Delete", "enquiry", new { id=item.ID })%>">
                            <img src="<%=Url.Content("~/images/delete.png") %>" border="0" alt="Delete" />
                        </a>
        </td>
            </tr>
            <% } %>
        </table>
    </div>
</asp:Content>
