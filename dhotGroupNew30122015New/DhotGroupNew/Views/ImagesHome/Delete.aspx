<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProfileMaster.Master" Inherits="System.Web.Mvc.ViewPage<DhotGroupNew.Models.tb_ImagesHomeDhot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div id="box3">


<h1>Delete Dance </h1>

<h3>Are you sure you want to delete this?</h3>

 <%Html.RenderPartial("comImages"); %>

 </div>
</asp:Content>
