<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HomeMaster.Master" Inherits="System.Web.Mvc.ViewPage<dhotGroup.Models.ProfileMaster>"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<% object objText = new {style = "width:200px;Height:20px" }; %>
 <% using (Html.BeginForm())
    {%>
  <div id="body_container">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="center" class="steps_forgotpass"><table width="98%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="219" height="44" align="left" class="txt_white"><h4><strong>FORGOT YOUR PASSWORD</strong></h4> <h5>to find your Sole Mate</h5></td>
        <td width="192" align="left" class="txt_white"><h4><strong>VARIFY YOUR IDENTITY</strong></h4> <h5>for members you like</h5></td>
        <td width="471" align="left" class="txt_white"><h4><strong>RESET YOUR PASSWORD</strong></h4> <h5>via emails, phone or chat</h5></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><table width="96%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="20%"  height="10"><img src="images/clr.gif" width="1" height="1" /></td>
        <td width="80%"></td>
      </tr>
      <tr>
        <td height="40"><h3>My NRIWeds.com ID is</h3></td>
        <td><%=Html.TextBox("emailid","", objText)%>
          <span class="txt_red">&nbsp;&nbsp;<%=Html.ValidationMessage("emailid")%></span></td>
      </tr>
       <tr>
        <td height="45">&nbsp;</td>
        <td><input  type="image" id="image"  src="<%=Url.Action("image")%>" alt="click to refresh" /></td>
      </tr>
      <tr>
        <td height="40"><h3>Enter the code shown</h3></td>
        <td><%= Html.TextBox("captchatext", "", objText)%><span class="txt_red">&nbsp;&nbsp;<%=Html.ValidationMessage("captchatext")%></span></td>
      </tr>
     
      <tr>
        <td height="45">&nbsp;</td>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="50%"><input type="image" src="../../images/btn_submit.gif" class="submitimg" value="Submit" /></td>
    <td width="50%"><h4><a href="#" class="txt_white">Forgot Password?</a></h4></td>
  </tr>
</table>

        </td>
      </tr>
      <tr>
        <td style="border-bottom:1px solid #fff;">&nbsp;</td>
        <td style="border-bottom:1px solid #fff;">&nbsp;</td>
      </tr>
      </table></td>
  </tr>
  <tr>
  <td height="10"></td>
  
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
  </table>

<%} %>
    
</div>
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
