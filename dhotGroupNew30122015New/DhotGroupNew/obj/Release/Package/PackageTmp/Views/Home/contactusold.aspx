<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HomeMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    contactus
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="box1">
        <div id="addressdiv">
            <table border="0" cellpadding="0" cellspacing="0" height="332" width="96%">
                <tbody>
                    <tr>
                        <th scope="col" height="332" width="80%" valign="top">
                            <h1>
                                <% = ViewData["pageTitle"]  %>
                            </h1>
                            <table width="100%">
                                <tr>
                                    <td valign="top" width="50%">
                                        <% = ViewData["PageDesc"] %>
                                    
                                    </td>
                                    <td width="50%">
                                        <iframe width="300" height="250" frameborder="0" scrolling="no" marginheight="0"
                                            marginwidth="0" src="https://maps.google.co.in/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=Delta:+%236993+Bison+Place+++++++++++++++++++++BC,+V4E2C1,+Canada&amp;aq=&amp;sll=49.147524,-122.867446&amp;sspn=0.009699,0.026157&amp;ie=UTF8&amp;hq=&amp;hnear=6993+Bison+Pl,+Delta,+British+Columbia+V4E+2C1,+Canada&amp;t=m&amp;z=14&amp;ll=49.129959,-122.8947&amp;output=embed">
                                        </iframe>
                                        <br />
                                        <small><a href="https://maps.google.co.in/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=Delta:+%236993+Bison+Place+++++++++++++++++++++BC,+V4E2C1,+Canada&amp;aq=&amp;sll=49.147524,-122.867446&amp;sspn=0.009699,0.026157&amp;ie=UTF8&amp;hq=&amp;hnear=6993+Bison+Pl,+Delta,+British+Columbia+V4E+2C1,+Canada&amp;t=m&amp;z=14&amp;ll=49.129959,-122.8947"
                                            style="color: #0000FF; text-align: left">View Larger Map</a></small>
                                        <br />
                                        <br />
                             
                                        <iframe width="300" height="250" frameborder="0" scrolling="no" marginheight="0"
                                            marginwidth="0" src="https://maps.google.co.in/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=+&amp;q=Surrey:+%23+105,+7829++%09+++128+Street,+Surrey++%09+++BC,+V3W4E8,+Canada&amp;ie=UTF8&amp;hq=&amp;hnear=7829+128+St+%23105,+Surrey,+Greater+Vancouver,+British+Columbia,+Canada&amp;t=m&amp;z=14&amp;ll=49.145492,-122.867958&amp;output=embed">
                                        </iframe>
                                        <br />
                                        <small><a href="https://maps.google.co.in/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=+&amp;q=Surrey:+%23+105,+7829++%09+++128+Street,+Surrey++%09+++BC,+V3W4E8,+Canada&amp;ie=UTF8&amp;hq=&amp;hnear=7829+128+St+%23105,+Surrey,+Greater+Vancouver,+British+Columbia,+Canada&amp;t=m&amp;z=14&amp;ll=49.145492,-122.867958"
                                            style="color: #0000FF; text-align: left">View Larger Map</a></small>
                                    </td>
                                </tr>
                            </table>
                        
                        </th>
                        <th scope="col" width="31%">
                            <table border="0" cellpadding="0" cellspacing="0" height="21" width="203">
                                <tbody>
                                    <tr>
                                        <td width="430">
                                            <br>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </th>
                    </tr>
                </tbody>
            </table>
            <blockquote>
                <blockquote>
                    <blockquote>
                        &nbsp;</blockquote>
                </blockquote>
            </blockquote>
       
        </div>
    </div>
</asp:Content>
