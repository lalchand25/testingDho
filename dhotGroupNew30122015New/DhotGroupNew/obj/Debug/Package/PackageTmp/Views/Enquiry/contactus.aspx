<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HomeMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<DhotGroupNew.Models.tb_ContactUs>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    contactus
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <!--2nd box -->
                <div class="main_frame">
           				
                        <div class="contuct_form_box">
                        
                        
                                <p><b>6 Degrees Entertainment.Net</b></ p> 
<p>#123, 7536 130 St. Surrey BC V3W 1H8</ p> 
<p><b>Tel: </b> 604 - 644 - 9551</ p> 
<p><b>Fax:</b> </ p> 

<p><b>Email:</b> info@6degreesentertainment.net</ p>
	
       <div class="contuctform">
        <%=ViewData["messageERR"] %>
        <% if (ViewData["messageERR"] == null)
           { %>
        <% object objText = new { style = "width:200px;Height:20px" }; %>
        <% using (Html.BeginForm())
           {%>
        <%= Html.ValidationSummary(true)%>
        <table style="width: 100%;" align="left">
            <%--  <tr>
                <td>
                     Subject
                </td>
                <td>
                    <div class="editor-field">
                        <%= Html.TextBoxFor(model => model.subject)%>
                        <%= Html.ValidationMessageFor(model => model.subject)%>
                    </div>
                </td>
            </tr>--%>
            <tr>
                <td>
                    First Name:
                </td>
                <td>
                    <div class="editor-field">
                        <%= Html.TextBoxFor(model => model.FirstName)%>
                        <%= Html.ValidationMessageFor(model => model.FirstName)%>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    Last Name:
                </td>
                <td>
                    <%= Html.TextBoxFor(model => model.LastName)%>
                    <%= Html.ValidationMessageFor(model => model.LastName)%>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    Email ID:
                </td>
                <td style="width: 75%;">
                    <div class="editor-field">
                        <%= Html.TextBoxFor(model => model.EmailId)%>
                        <%= Html.ValidationMessageFor(model => model.EmailId)%>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    Contact No.:
                </td>
                <td>
                    <div class="editor-field">
                        <%= Html.TextBoxFor(model => model.ContactNo)%>
                        <%= Html.ValidationMessageFor(model => model.ContactNo)%>
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Comments:
                </td>
                <td>
                    <div class="editor-field">
                        <%= Html.TextAreaFor(model => model.Comments, new { style = "width:300px;height:80px;" })%>
                        <%= Html.ValidationMessageFor(model => model.Comments)%>
                    </div>
                </td>
            </tr>
            <%--   <tr>
                <td valign="top">
                    &nbsp;
                </td>
                <td>
                    <div class="editor-label">
                        <input type="image" id="image" src="<%=Url.Action("image")%>" alt="click to refresh" />
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Enter Text
                </td>
                <td>
                    <div class="editor-field">
                        <%= Html.TextBox("captchatext", "", objText)%><span class="txt_red">&nbsp;&nbsp;<%=Html.ValidationMessage("captchatext")%>
                    </div>
                </td>
            </tr>--%>
            <tr>
                <td style="height: 30px">
                </td>
                <td style="height: 30px">
                    <input type="submit" value="Submit" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <% } %>
        <%}
           else
           { %>
        <h3>
            <%= ViewData["message"]%></h3>
        <%} %>
    </div>

                 <div class="map">
                 	<iframe width="300" height="300" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.co.in/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=7536+130+St+%23123,+Surrey,+BC,+Canada&amp;aq=1&amp;oq=123,+7536+130+St.+Surrey+BC+V3W+1H8&amp;sll=30.712482,76.78402&amp;sspn=0.27362,0.359802&amp;ie=UTF8&amp;hq=&amp;hnear=7536+130+St+%23123,+Surrey,+British+Columbia+V3W+1H8,+Canada&amp;t=m&amp;z=14&amp;ll=49.139446,-122.861413&amp;output=embed"></iframe><br /><small><a href="https://maps.google.co.in/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=7536+130+St+%23123,+Surrey,+BC,+Canada&amp;aq=1&amp;oq=123,+7536+130+St.+Surrey+BC+V3W+1H8&amp;sll=30.712482,76.78402&amp;sspn=0.27362,0.359802&amp;ie=UTF8&amp;hq=&amp;hnear=7536+130+St+%23123,+Surrey,+British+Columbia+V3W+1H8,+Canada&amp;t=m&amp;z=14&amp;ll=49.139446,-122.861413" style="color:#0000FF;text-align:left">View Larger Map</a></small>
                 
                 </div>      
                        
                        
                        </div>
                 
                </div>


    
    




  
</asp:Content>
