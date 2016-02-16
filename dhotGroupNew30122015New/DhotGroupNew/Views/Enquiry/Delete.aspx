<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProfileMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<DhotGroupNew.Models.tb_EnquiryDhot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="right_body">
        <h4>
            Delete
        </h4>
        <div class="profile_center_white">
            <div class="search">
                <h3>
                    Are you sure you want to delete this?</h3>
                       <table width="50%"> <tr> <td> 
                <fieldset>
            

                 <table width="100%"> <tr> <td width="25%"> <div class="display-label">
                        First Name :</div> </td> <td width="20%"><div class="display-field">
                        <%: Html.DisplayFor(model => model.FirstName) %>
                    </div> </td> <td width="50%"> </td> </tr> 
                    
                    <tr> <td> &nbsp; </td> <td> </td> <td> </td> </tr>
                    <tr> <td>   <div class="display-label">
                        Last Name :</div> </td> <td>   <div class="display-field">
                        <%: Html.DisplayFor(model => model.LastName) %>
                    </div></td> <td> </td></tr>
                    <tr> <td> &nbsp; </td> <td> </td> <td> </td> </tr>
                    
                 
                     <tr> <td>     <div class="display-label">
                        Contact No :</div></td> <td>   <div class="display-field">
                        <%: Html.DisplayFor(model => model.ContactNo) %>
                    </div></td> <td> </td></tr> 
                 
                    <tr> <td> &nbsp; </td> <td> </td> <td> </td> </tr>
              
                  <tr> <td>     <div class="display-label">
                        Comments :</div></td> <td>   <div class="display-field">
                        <%: Html.DisplayFor(model => model.Comments)%>
                    </div></td> <td> </td></tr> 
                    <tr> <td> &nbsp; </td> <td> </td> <td> </td> </tr>

                        <tr> <td>     <div class="display-label">

                        Company :</div></td> <td>   <div class="display-field">
                        <%: Html.DisplayFor(model => model.Company)%>
                    </div></td> <td> </td></tr> 
                    <tr> <td> &nbsp; </td> <td> </td> <td> </td> </tr>

                        <tr> <td>     <div class="display-label">

                        Enquiry Type :</div></td> <td>   <div class="display-field">

                        <%: Html.DisplayFor(model => model.EnquiryType)%>
                    </div></td> <td> </td></tr> 
                   
                    </table>
              
                </fieldset>
                    </td></tr></table>
                 
                <% using (Html.BeginForm())
                   { %>
                <p>
                    <input type="submit" value="Delete" />
                    |
                    <%: Html.ActionLink("Back to List", "Index") %>
                </p>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>
