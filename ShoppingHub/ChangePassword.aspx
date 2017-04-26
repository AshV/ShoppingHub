<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Shopping HUB | An Online Store</title>
    <link href="Styles/menu.css" type="text/css" rel="Stylesheet" />
    <link href="css/style.css" rel="stylesheet" type="text/css"/>
<link href="css/ddsmoothmenu.css" rel="stylesheet" type="text/css"/>
<link rel="stylesheet" type="text/css" href="css/jquery.css" media="screen"/>
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
    <form id="form1" runat="server">
    <div>
    <div style="left: 599.5px; top: 166px;" class="ddshadow toplevelshadow"></div><div style="left: 512.5px; top: 166px;" class="ddshadow toplevelshadow"></div><div style="left: 327.5px; top: 166px;" class="ddshadow toplevelshadow"><div style="left: 190px; top: 10px;" class="ddshadow"></div></div><div style="left: 586.5px; top: 166px;" class="ddshadow toplevelshadow"></div><div style="left: 501.5px; top: 166px;" class="ddshadow toplevelshadow"></div><div style="left: 321.5px; top: 166px; overflow: hidden; height: 0px; display: block;" class="ddshadow toplevelshadow"><div style="left: 190px; top: 10px;" class="ddshadow"></div></div>
<div id="wrapper_sec">
	<div class="inner">
    	<!-- Header -->
        <div id="masthead">
        	<div class="topsec">
                <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                <ul class="lang">
                	
                </ul>
            </div>
            <div class="logosec">
            	<div class="logo">
                	<a href="#"><img src="images/logo.png" alt=""></a>
                    <h5>WORLD OF FRAGRANCES</h5>
					</div>
                <div class="cartsec cufontxt">BEST DEAL YOU CAN GET</div>
            </div>
            <div class="navigation">
            	<div id="smoothmenu1" class="ddsmoothmenu">
                    <ul>
                        <li><a href="Default.aspx" class="cufontxt upper">HOME</a></li>
                        <li><a href="AboutUs.aspx" class="cufontxt upper">ABOUT US</a></li>
                        <li><a href="ContactUs.aspx" class="cufontxt upper">CONTACT US</a></li>
                    </ul>
                <div class="clear"></div>
                </div>
            	<div class="search">
                    <asp:TextBox ID="searchBox" runat="server" value="Enter keyword to search"  name="s" onblur="if(this.value == '') { this.value = 'Enter keyword to search'; }" onfocus="if(this.value == 'Enter keyword to search') { this.value = ''; }" class="bar"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        DataSourceID="SqlDataSource2" DataTextField="catname" DataValueField="catid" >
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ShoppingHubCS %>" 
                        SelectCommand="SELECT [catid], [catname] FROM [category]">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="catid" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:Button ID="Button1" runat="server" Text="SEARCH" />
                </div>
            </div>
        </div>
    </div>
    <div class="clear"></div>
    <!-- Banner -->
    <div id="banner">
    	<div class="inner">
        	<div id="slider2" style="overflow:hidden; height:313px;">
                <div style="display: block; z-index: 1; opacity: 1; visibility: visible;" class="contentdiv"><a href="prod_detail.html"><img src="images/banner1.jpg" alt=""></a></div>
                <div style="display: none;" class="contentdiv"><a href="prod_detail.html"><img src="images/banner1.jpg" alt=""></a></div>
                <div style="display: none;" class="contentdiv"><a href="prod_detail.html"><img src="images/banner1.jpg" alt=""></a></div>
            </div>
            <div id="paginate-slider2">
                <a href="#" class="prev">&nbsp;</a>
                <a href="#" class="next">&nbsp;</a>
            </div>
        	<script type="text/javascript" src="images/banner.js"></script>
        </div>
    </div>
    <!-- Content Section -->
    <div class="inner">
    	<div id="content_sec">
        	<!-- Column 1 -->
        	<div class="col1">
            	<!-- Categories --><!-- Compare Products -->
              <div class="categories">
                	<h5 class="small_head">ALL CATEGORIES</h5>
                  <div class="menu">
                      <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" CssClass="menu">
                          <ItemTemplate>
                              <asp:Label ID="catlinkLabel" runat="server" Text='<%# Eval("catlink") %>' />
                              <br />
<br />
                          </ItemTemplate>
                      </asp:DataList>
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                          ConnectionString="<%$ ConnectionStrings:ShoppingHubCS %>" 
                          SelectCommand="SELECT [catlink] FROM [category] WHERE ([active] = @active)">
                          <SelectParameters>
                              <asp:Parameter DefaultValue="Yes" Name="active" Type="String" />
                          </SelectParameters>
                      </asp:SqlDataSource>
                  </div>
                </div>
            <!-- Community Poll --></div>
            <!-- Column 2 -->
        	<div class="col2">
            	<!-- Featured Products -->
                <div class="clear"></div>
                <!-- Product Listing -->
                <div class="prlisting">
                <br />
                <font color="#111111" size="+2">
                    <table class="style1" align="center">
                        <tr>
                            <td colspan="2"><br />
                               <center> <asp:Label ID="Label2" runat="server" Text="Change Password"></asp:Label></center><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Current Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="New Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Confirm Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="Change Password" 
                                    onclick="Button2_Click" />
                            </td>
                        </tr>
                    </table>
                    </font>
                    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="clear"></div>
   <!-- Footer -->
    <div id="footer">
    	<div class="inner">

        	<!-- Footer Top Section -->
            <div class="clear"></div>

            <div class="footer_sec">
            	<div class="company">
                	<h4>Company</h4>
                    <ul>
                        <li><a href="Default.aspx">Home</a></li>
                    	<li><a href="AboutUs.aspx">About Us</a></li>
                        <li><a href="ContactUs.aspx">Contact Us</a></li>
                    </ul>
                </div>
                
                <div class="community">
                	<h4>Community</h4>

                    <ul>
                    	<li><a href="#"><img src="images/foot_icon1.gif" alt="" /> YouTube</a></li>
                        <li><a href="#"><img src="images/foot_icon2.gif" alt="" /> Facebook</a></li>
                    </ul>
                </div>
                <div class="footlogo">
                	<a href="Default.aspx" class="small_logo"><img src="images/logo.png" alt="" /></a>
                    <h6>World of Fragrance</h6>
                </div>
                <div class="clear"></div>
                <div class="copyrights">

                	<p>Copyright ©2013 Shopping HUB. All Rights Reserved</p>
                    <a href="#" class="top">Top</a>
                </div>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</div>

    </div>
    </form>
</body>
</html>
