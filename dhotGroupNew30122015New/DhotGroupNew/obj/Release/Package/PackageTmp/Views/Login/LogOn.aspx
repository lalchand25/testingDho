<%@ Page Language="C#" MasterPageFile="~/Views/Shared/HomeMaster.Master" Inherits="System.Web.Mvc.ViewPage<DhotGroupNew.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Session["projectmetatags"]%>
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        input#UserName
        {
            width: 200px;
        }
        
        input#Password
        {
            width: 200px;
        }
    </style>
    <!--top box-->
    <div id="box1">
        <h1>
            User Login Are
        </h1>
        <p>
            Please enter your username and password.
            <%--       <%=Html.ActionLink("Register", "create","Register") %>
            if you don't have an account.--%>
        </p>
        <p>
            <% using (Html.BeginForm())
               { %>
            <%=Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
            <%=Html.Hidden("returnurl",ViewData["returnurl"]) %>
            <table width="60%">
                <tr>
                    <td>
                        User Name:
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= Html.EditorFor(m => m.UserName,  new { style = "width:150px:Height:25px" })%>
                        <%= Html.ValidationMessageFor(m => m.UserName) %>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password:
                    </td>
                </tr>
                <tr>
                    <td>
                        <%= Html.PasswordFor(m => m.Password, new { style = "width:150px:Height:52px" })%>
                        <%= Html.ValidationMessageFor(m => m.Password) %>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="submit" value="Log On" />
                    </td>
                </tr>
            </table>
                 <p>
            forgot password.
            <%=Html.ActionLink("Get Password", "forgotpassword","Login") %>
        </p>
            <br />
            <% } %>
            <%--   <div class="map">
        <%=ViewData["pagedescription"] %>
    </div>
            --%>
            <br />
            <br />
        </p>
    </div>




</asp:Content>
