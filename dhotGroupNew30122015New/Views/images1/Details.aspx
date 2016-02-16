<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HomeMaster.Master" Inherits="System.Web.Mvc.ViewPage<DhotGroupNew.Models.tb_ImagesDhot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
	<script type="text/javascript" src="../../js/jawdropper_slider.min.js"></script>
	<link rel="stylesheet" href="../../css/jawdropper_slider.css" type="text/css" />
	
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    
    
	<link rel="stylesheet" type="text/css" href="../../style-projects-jquery.css" />    
    
    <!-- Arquivos utilizados pelo jQuery lightBox plugin -->
    
    <script type="text/javascript" src="../../js/jquery.lightbox-0.5.js"></script>
    <script src="../../SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../../css/jquery.lightbox-0.5.css" media="screen" />
    <!-- / fim dos arquivos utilizados pelo jQuery lightBox plugin -->
    
    <!-- Ativando o jQuery lightBox plugin -->
    <script type="text/javascript">
        $(function () {
            $('#gallery a').lightBox();
        });
    </script>
  
    <link href="../../SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />




  <div class="main_frame">
                
                
                <h1>Gallery</h1>
                      <div class="scrolldiv2"> 
                <div id="gallery">
    <ul>
        <li><a href="../../photos/image1.jpg" title=""><img src="../../photos/thumb_image1.jpg" width="150" height="150" alt="" /></a></li>
        <li>
            <a href="../../photos/image2.jpg" title="">
            <img src="../../photos/thumb_image2.jpg" width="150" height="150" alt="" />            </a>        </li>
                    <li>
            <a href="../../photos/image6.jpg" title="">
            <img src="../../photos/thumb_image6.jpg" width="150" height="150" alt="" />            </a>        </li>
                    <li>
            <a href="../../photos/image7.jpg" title="">
            <img src="../../photos/thumb_image7.jpg" width="150" height="150" alt="" />            </a>        </li>
                    <li>
            <a href="../../photos/image8.jpg" title="">
            <img src="../../photos/thumb_image8.jpg" width="150" height="150" alt="" />            </a>        </li>
        <li>
            <a href="../../photos/image3.jpg" title="">
            <img src="../../photos/thumb_image3.jpg" width="150" height="150" alt="" />            </a>        </li>
        <li>
            <a href="../../photos/image4.jpg" title="">
            <img src="../../photos/thumb_image4.jpg" width="150" height="150" alt="" />            </a>        </li>
        <li>
            <a href="../../photos/image5.jpg" title="">
            <img src="../../photos/thumb_image5.jpg" width="150" height="150" alt="" />            </a>        </li>
    </ul>
</div>
                
                </div>
                
                    </div>
</asp:Content>
