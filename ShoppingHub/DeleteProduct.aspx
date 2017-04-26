<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteProduct.aspx.cs" Inherits="DeleteProduct" %>

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
                    <ul>
                        <li><a href="AdminHome.aspx" class="cufontxt upper">HOME</a></li>
                        <li style="z-index: 100;"><a style="padding-right: 23px;" href="#" class="cufontxt upper">Add<img src="images/navi_down.gif" class="downarrowclass" style="border: 0pt none;"><img src="images/navi_down.gif" class="downarrowclass" style="border: 0pt none;"></a>
                            <ul style="display: none; top: 36px; visibility: visible;">
                                <li><a href="AddNewCategory.aspx">Category</a></li>
                                <li><a href="AddNewBrand.aspx">Brand</a></li>
                                <li><a href="AddNewProduct.aspx">Product</a></li>  
                            </ul>
                        </li>
                         <li style="z-index: 100;"><a style="padding-right: 23px;" href="#" class="cufontxt upper">Delete<img src="images/navi_down.gif" class="downarrowclass" style="border: 0pt none;"><img src="images/navi_down.gif" class="downarrowclass" style="border: 0pt none;"></a>
                            <ul style="display: none; top: 36px; visibility: visible;">
                                <li><a href="DeleteCategory.aspx">Category</a></li>
                                <li><a href="DeleteBrand.aspx">Brand</a></li>
                                <li><a href="DeleteProduct.aspx">Product</a></li>  
                            </ul>
                        </li>
                         <li style="z-index: 100;"><a style="padding-right: 23px;" href="#" class="cufontxt upper">Modify<img src="images/navi_down.gif" class="downarrowclass" style="border: 0pt none;"><img src="images/navi_down.gif" class="downarrowclass" style="border: 0pt none;"></a>
                            <ul style="display: none; top: 36px; visibility: visible;">
                                <li><a href="ModifyCategory.aspx">Category</a></li>
                                <li><a href="ModifyBrand.aspx">Brand</a></li>
                                <li><a href="ModifyProduct.aspx">Product</a></li>  
                            </ul>
                        </li>
                       <li><a href="ManageUsers.aspx" class="cufontxt upper">Manage Users</a></li>
                       <li><a href="viewEnquiries.aspx" class="cufontxt upper">View Enquiries</a></li>
                      <li><a href="AdminLogOut.aspx" class="cufontxt upper">Log Out</a></li>
                    </ul>
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

     <table class="style1">
            <tr>
                <td>
                   <br /><center>Delete Brand</center><br /></td>
            </tr>
            <tr>
                <td>
                <div style="background-color:#333;">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="prodid" HeaderText="Prod ID" 
                                SortExpression="prodid" />
                            <asp:BoundField DataField="catid" HeaderText="Cat ID" SortExpression="catid" />
                            <asp:BoundField DataField="prodname" HeaderText="Name" 
                                SortExpression="prodname" />
                            <asp:BoundField DataField="purprice" HeaderText="Purchase Price" 
                                SortExpression="purprice" />
                            <asp:BoundField DataField="saleprice" HeaderText="Sale Price" 
                                SortExpression="saleprice" />
                            <asp:BoundField DataField="brandid" HeaderText="Brand Id" 
                                SortExpression="brandid" />
                            <asp:BoundField DataField="brandimg" HeaderText="Image" 
                                SortExpression="brandimg" />
                            <asp:BoundField DataField="active" HeaderText="Active" 
                                SortExpression="active" />
                            <asp:BoundField DataField="avail" HeaderText="Avail" SortExpression="avail" />
                            <asp:BoundField DataField="description" HeaderText="description" 
                                SortExpression="description" />
                            <asp:BoundField DataField="featured" HeaderText="Featured" 
                                SortExpression="featured" />
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ShoppingHubCS %>" 
                        SelectCommand="SELECT * FROM [prodtab]"></asp:SqlDataSource>
                        </div>

                   </td>
            </tr>
        </table>
       
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
</center>
</body>
</html>
