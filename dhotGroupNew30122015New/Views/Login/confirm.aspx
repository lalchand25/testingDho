<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HomeMaster.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
<%=Session["projectmetatags"]%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Confirmation</h2>
     <%=ViewData["results"] %>  
     <p>
        Click here to redirect on login page. <%=Html.ActionLink("Login", "logon","login") %> 
    </p>
</asp:Content>
