<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HomeMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<DhotGroupNew.Models.LogOnModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Session["projectmetatags"]%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="box1">
        <h4>
            Forgot Password</h4>
        <% object objText = new { style = "width:200px;Height:20px" }; %>
        <% using (Html.BeginForm())
           { %>
        <%=Html.ValidationSummary(true, "Email ID is not correct, Please correct the errors and try again.") %>
        <div>
            <div class="editor-label">
                Enter Email Id:
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(m => m.UserName, new { style="width:200px" })%>
                <%= Html.ValidationMessageFor(m => m.UserName) %>
            </div>
       <%--     <div class="editor-label">
                <input type="image" id="image" src="<%=Url.Action("image")%>" alt="click to refresh" />
            </div>--%>
            <%--      <div class="editor-label">
                   Enter Text 
                </div>
                <div class="editor-field">
                   <%= Html.TextBox("captchatext", "", objText)%><span class="txt_red">&nbsp;&nbsp;<%=Html.ValidationMessage("captchatext")%>
                </div>
            --%>
            <p>
                <input type="submit" value="Get Password" />
            </p>
        </div>
        <br />
        <% } %>
    </div>
    <div class="map">
        <%= ViewData["pagedescription"]%>
    </div>
 
</asp:Content>
