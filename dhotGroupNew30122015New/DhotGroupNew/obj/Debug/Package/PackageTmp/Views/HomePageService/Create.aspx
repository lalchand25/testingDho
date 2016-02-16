<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProfileMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<DhotGroupNew.Models.tb_HomePageServicesDhot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="box3">
        <h1>
            Create Services
        </h1>
        <%Html.RenderPartial("comHomePageService"); %>
    </div>
</asp:Content>
