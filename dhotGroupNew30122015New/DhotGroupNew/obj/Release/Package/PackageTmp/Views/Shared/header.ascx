<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%--   <div class="top_line">
    </div>
    <div class="main_header">
        <div class="header">
            <div class="logo_left">
            </div>
            <div class="login_button">
                <a href="#">
                    <img src="../../images/login_button.png" /></a></div>
            <div class="logo_right">
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


    <div class="main_banner">
        <div class="banner">
            <div id="slider" class='jdslider'>
                <a href="#">
                    <img src="../../images/banner.jpg" alt="Your Text" /></a> <a href="#">
                        <img src="../../images/banner1.jpg" alt="Your Text" /></a> <a href="#">
                            <img src="../../images/banner2.jpg" alt="Your Text" /></a>
            </div>
        </div>
    </div>

      <div class="main_menu">
        <div class="menu">
            <div id="btns">
                <ul>
                    <li><a href="index.html">Home</a></li>
                    <li><a href="aboutus.html">About Us</a></li>
                    <li><a href="#">Services</a></li>
                    <li><a href="#">Events</a></li>
                    <li><a href="#">Contact Us</a></li>
                </ul>
            </div>
        </div>
    </div>
--%>
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
<div class="main_banner">
    <div class="banner">
        <div id="slider" class='jdslider'>
               <a href="#">
                    <img src="../../images/banner.jpg" alt="Your Text" /></a>
                   <%--  <a href="#">
                        <img src="../../images/banner1.jpg" alt="Your Text" /></a>
                         <a href="#">
                            <img src="../../images/banner2.jpg" alt="Your Text" />
                            </a>--%>

            <%=Session["banner"]  %>

        </div>
    </div>
</div>
<div class="main_menu">
    <div class="menu">
        <div id="btns">
            <ul>
                <li><a href="/home">Home</a></li>
                <li><a href="/home/about">About Us</a></li>
                <li>         <a href="/home/services">Services</a></li>
                     <li><a href="#">Events</a></li>
                    <li><a href="/home/contactus">Contact Us </a>
                    </li>

            </ul>
        </div>
    </div>
</div>
