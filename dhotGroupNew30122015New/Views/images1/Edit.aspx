<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProfileMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<DhotGroupNew.Models.tb_ImagesDhot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
  <div id="box3">

        <h1>
            Edit Images</h1>
  <%Html.RenderPartial("comImages"); %>
    </div>
</asp:Content>
