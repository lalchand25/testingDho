<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HomeMaster.Master"
    Inherits="System.Web.Mvc.ViewPage<DhotGroupNew.Models.tb_EnquiryDhot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    contactus
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="box1">
        <h1>
            Thanks
        </h1>
        <br />
        <%=Session["messageERR"]%>
        <br />
        <p>
            &nbsp;&nbsp; Please check your email id and send again
        </p>
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
