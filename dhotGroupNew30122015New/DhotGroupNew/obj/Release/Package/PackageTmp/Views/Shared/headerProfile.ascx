<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headerProfile.ascx.cs"
    Inherits="DhotGroupNew.Views.Shared.headerProfile" %>


<div class="top_line">
</div>
<div class="main_header">
    <div class="header">
        <div class="logo_left">
            <img src="/uploads/<%=Session["logohome"]  %> " width="153" height="123" />
        </div>
        <div class="login_button">
            <a href="/login/logon">
                <img src="../../images/login_button.png" /></a>
        </div>
        <div class="logo_right">
            <h2>
                <%=Session["HomeName1"]  %>
            </h2>
            <h3>
                <%=Session["HomeName2"]  %>
            </h3>
            <%--<img src="/uploads/<%=Session["logohome"]  %> " width="291" height="56" />--%>
        </div>
        <div class="follow">
            <img src="../../images/follow-us.png" border="0" usemap="#Map" />
            <map name="Map" id="Map">
                <area shape="rect" coords="5,6,34,32" href="#" />
                <area shape="rect" coords="43,6,71,34" href="#" />
                <area shape="rect" coords="84,5,108,32" href="#" />
                <area shape="rect" coords="119,4,149,30" href="#" />
                <area shape="rect" coords="158,4,189,32" href="#" />
            </map>
        </div>
    </div>
</div>

<div class="main_menu">
    <div class="menu">
        <div id="btns">
            <ul>
              <li><a href="/home">Home</a></li><li><a href="/profile/profile">Profile</a></li>

            </ul>
        </div>
    </div>
</div>

