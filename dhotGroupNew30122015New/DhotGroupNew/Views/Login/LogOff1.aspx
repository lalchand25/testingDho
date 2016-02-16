<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/homePMS.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%=Session["projectmetatags"]%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Thanks for using this system.......</h2>

</asp:Content>
