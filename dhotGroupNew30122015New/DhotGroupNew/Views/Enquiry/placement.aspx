<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HomeMaster.Master" Inherits="System.Web.Mvc.ViewPage<DhotGroupNew.Models.tb_EnquiryDhot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    placemen
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

   <div id="box1">
        <h1>
            Placement</h1>
        <%--   <h1> <% = ViewData["pageTitle"]  %> </h1>--%>
        <%--   <% = ViewData["PageDesc"] %> --%>


 <%Html.RenderPartial("comEnquiry"); %>

 </div>

</asp:Content>
