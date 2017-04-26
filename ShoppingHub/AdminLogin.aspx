<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="admLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Fragrance Shop</title>
<!-- // Stylesheet // -->
<link href="css/style.css" rel="stylesheet" type="text/css">
<link href="css/ddsmoothmenu.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" type="text/css" href="css/jquery.css" media="screen">
<!-- // Javascript // -->
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/ddsmoothmenu.js"></script>
<script type="text/javascript" src="js/menu.js"></script>
<script type="text/javascript" src="js/bannercontentslider.js"></script>
<script type="text/javascript" src="js/ddaccordion.js"></script>
<script type="text/javascript" src="js/acordin.js"></script>
<style type="text/css">
.categoryitems{display: none}
a.hiddenajaxlink{display: none}
</style><style type="text/css">
.subcategoryitems{display: none}
a.hiddenajaxlink{display: none}
</style><style type="text/css">
.categoryitems{display: none}
a.hiddenajaxlink{display: none}
</style><style type="text/css">
.subcategoryitems{display: none}
a.hiddenajaxlink{display: none}
</style>
<script type="text/javascript" src="js/jquery_002.js"></script>
<script type="text/javascript" src="js/scroll.js"></script>
<script type="text/javascript" src="js/cufon-yui.js"></script>
<style type="text/css">
@media screen,projection{.cufon-canvas{display:inline;display:inline-block;position:relative;vertical-align:middle;font-size:1px;line-height:1px}.cufon-canvas .cufon-alt{display:none}.cufon-canvas canvas{position:relative}}
@media print{.cufon-canvas{padding:0 !important}.cufon-canvas canvas{display:none}.cufon-canvas .cufon-alt{display:inline}} 
</style>
<style type="text/css">
@media screen,projection{.cufon-canvas{display:inline;display:inline-block;position:relative;vertical-align:middle;font-size:1px;line-height:1px}.cufon-canvas .cufon-alt{display:none}.cufon-canvas canvas{position:relative}}@media print{.cufon-canvas{padding:0 !important}.cufon-canvas canvas{display:none}.cufon-canvas .cufon-alt{display:inline}} 
    </style>
<script type="text/javascript" src="js/Tahoma_400-Tahoma_700.js"></script>
<script type="text/javascript">    Cufon.replace('h1, h2, h3, h4, h5, h6, .cufontxt');</script>
<script type="text/javascript" src="js/jquery_003.js"></script>
<script type="text/javascript" src="js/lightbox.js"></script>
<script type="text/javascript" src="js/prodscroller.js"></script>
<script type="text/javascript" src="js/tabs.js"></script>
</head>
<body>
<center>
    <form id="form1" runat="server">
    <div>
    <div style="left: 599.5px; top: 166px;" class="ddshadow toplevelshadow"></div><div style="left: 512.5px; top: 166px;" class="ddshadow toplevelshadow"></div><div style="left: 327.5px; top: 166px;" class="ddshadow toplevelshadow"><div style="left: 190px; top: 10px;" class="ddshadow"></div></div><div style="left: 586.5px; top: 166px;" class="ddshadow toplevelshadow"></div><div style="left: 501.5px; top: 166px;" class="ddshadow toplevelshadow"></div><div style="left: 321.5px; top: 166px; overflow: hidden; height: 0px; display: block;" class="ddshadow toplevelshadow"><div style="left: 190px; top: 10px;" class="ddshadow"></div></div>
<div id="wrapper_sec">
	<div class="inner">
    	<!-- Header -->
        <div id="masthead">
        	<div class="topsec">
            	
          </div>
            <div class="logosec">
            	<div class="logo">
                	<a href="#"><img src="images/logo.png" alt=""></a>
                    <h5><font size="+5"> Administrtor Panel</font></h5>
					</div>
            </div>
            <div class="navigation">
            	<div id="smoothmenu1" class="ddsmoothmenu">
                <div class="clear"></div>
                </div>
            	<div  >
                	
                </div>
            </div>
        </div>
    </div>
    <div class="clear"></div>
    <!-- Banner --><!-- Content Section -->
    <div class="inner" style="background-color:#333;">
    <font color="#FFFFFF" size="+2">
    	<br />
         <br />
        <br />
        <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate">
        </asp:Login>
        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
        <br />
        <br />
        <br />
     </font>
  </div>
    <div class="clear"></div>
   <!-- Footer -->
    <div id="footer">
    	<div class="inner">

        	<!-- Footer Top Section -->
        	<div class="clear"></div>

            <div class="footer_sec">
              <div class="copyrights">

           	    <p>Copyright ©2013 Shopping HUB. All Rights Reserveddd</p>
                    <a href="#" class="top">Top</a>
                </div>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</div>

    </div>
    </form>
</center>
</body>
</html>
