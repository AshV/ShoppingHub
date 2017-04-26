using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();    //making connection object 
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString;    //establishing connection to database
        //Checking if No user is logged in and Showing User menu according to user state
        if ((Session["uid"] == "") || (Session["uid"] == null))
        {
            Label userMenu = new Label();
            userMenu.Text = "<ul class='links'><li class='bold first'>Welcome Guest!</li><li><a href='SignUp.aspx'>My Account</a></li><li><a href='SignUp.aspx'>My Wishlist</a></li><li><a href='SignUp.aspx'>My Cart</a></li><li><a href='SignUp.aspx'>Checkout</a></li><li><a href='UserLogin.aspx'>Log In</a></li></ul>";
            userMenu.ID = "userMenu";
            PlaceHolder2.Controls.Add(userMenu);
        }
        else
        {
            string usr = "select fname from useracc where uid='"+Convert.ToInt32(Session["uid"])+"'";
            SqlDataAdapter da2 = new SqlDataAdapter(usr, con);
            DataSet ds2 = new DataSet();
            DataRow dr2;
            con.Open();
            da2.Fill(ds2, "name");
            con.Close();
            dr2 = ds2.Tables["name"].Rows[0];
            string nm = Convert.ToString(dr2["fname"]);
            Label userMenu = new Label();
            userMenu.Text = "<ul class='links'><li class='bold first'>Welcome " + nm + "!</li><li><a href='UserHome.aspx'>My Account</a></li><li><a href='Wishlist.aspx'>My Wishlist</a></li><li><a href='Cart.aspx'>My Cart</a></li><li><a href='Payment.aspx'>Checkout</a></li><li><a href='LogOut.aspx'>Log Out</a></li></ul>";
            userMenu.ID = "userMenu";
            PlaceHolder2.Controls.Add(userMenu);
        }
        try
        {
            // Retrieving all the categories from database and showing them in Datalist Control as Left menu 
            string str = "select catid,catname,catlink,active from category where active='Yes'"; 
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            DataRow dr;
            con.Open();
            da.Fill(ds, "category");
            con.Close();
            string[,] dytab = new string[9, 9];
            for (int i = 0; i < ds.Tables["category"].Rows.Count; i++)
            {
                dr = ds.Tables["category"].Rows[i];
                string cid = Convert.ToString(dr["catid"]);
                string cname = Convert.ToString(dr["catname"]);
                string clink = Convert.ToString(dr["catlink"]);
                //retrieving featured product list from all the categories which are active
                string str1 = "select prodid,prodname,saleprice,brandimg from prodtab where catid='" + cid + "' and active='Yes' and avail='Yes' and featured='Yes'";
                SqlDataAdapter da1 = new SqlDataAdapter(str1, con);
                DataSet ds1 = new DataSet();
                DataRow dr1;
                con.Open();
                da1.Fill(ds1, "product");
                con.Close();
                for (int k = 0; k < ds1.Tables["product"].Rows.Count; k++)
                {
                    for (int j = 0; j < ds1.Tables["product"].Columns.Count; j++)
                    {
                        dr1 = ds1.Tables["product"].Rows[k];
                        dytab[k, j] = Convert.ToString(dr1[j]);
                        Label1.Text += dytab[k, j];
                    }
                }
                //Displaying all the retrieved product according to categories in stacked tabular form
                int catid = Convert.ToInt32(cid);
                Label featuredboxlbl = new Label();
                //creating category wise featured product tab dynamically
                featuredboxlbl.Text = "<table width='100%' border='3' id='mainprodcontainer'> <tr> <td><table width='100%' > <tr> <td align='left'><div id='prodhead'>" + clink + "</div></td> </tr> <tr> <td><table width='100%' ><tr> <td><table width='100%' id='prodcantainer'><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[0, 0] + "'><img src=" + dytab[0, 3] + " /></a></td></tr><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[0, 0] + "'>" + dytab[0, 1] + "</a></td></tr><tr><td align='center'><a href='WishList.aspx?prodid=" + dytab[0, 0] + "'><img src='img/addtowishlist.gif' alt='Add Product To WishList' /></a></td></tr><tr><td align='center'><a href='Cart.aspx?prodid=" + dytab[0, 0] + "'><img src='img/addtocart.gif' alt='Add Product To Cart' /></a></td></tr><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[0, 0] + "'>Rs." + dytab[0, 2] + "</a></td></tr></table></td><td><table width='100%' id='prodcantainer'><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[1, 0] + "'><img src=" + dytab[1, 3] + " /></a></td></tr><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[1, 0] + "'>" + dytab[1, 1] + "</a></td></tr><tr><td align='center'><a href='WishList.aspx?prodid=" + dytab[0, 0] + "'><img src='img/addtowishlist.gif' alt='Add Product To WishList' /></a></td></tr><tr><td align='center'><a href='Cart.aspx?prodid=" + dytab[0, 0] + "'><img src='img/addtocart.gif' alt='Add Product To Cart' /></a></td></tr><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[1, 0] + "'>Rs." + dytab[1, 2] + "</a></td></tr></table></td><td><table width='100%' id='prodcantainer'><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[2, 0] + "'><img src=" + dytab[2, 3] + " /></a></td></tr><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[2, 0] + "'>" + dytab[2, 1] + "</a></td></tr><tr><td align='center'><a href='WishList.aspx?prodid=" + dytab[0, 0] + "'><img src='img/addtowishlist.gif' alt='Add Product To WishList' /></a></td></tr><tr><td align='center'><a href='Cart.aspx?prodid=" + dytab[0, 0] + "'><img src='img/addtocart.gif' alt='Add Product To Cart' /></a></td></tr><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[2, 0] + "'>Rs." + dytab[2, 2] + "</a></td></tr></table></td><td><table width='100%' id='prodcantainer'><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[3, 0] + "'><img src=" + dytab[3, 3] + " /></a></td></tr><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[3, 0] + "'>" + dytab[3, 1] + "</a></td></tr><tr><td align='center'><a href='WishList.aspx?prodid=" + dytab[0, 0] + "'><img src='img/addtowishlist.gif' alt='Add Product To WishList' /></a></td></tr><tr><td align='center'><a href='Cart.aspx?prodid=" + dytab[0, 0] + "'><img src='img/addtocart.gif' alt='Add Product To Cart' /></a></td></tr><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dytab[3, 0] + "'>Rs." + dytab[3, 2] + "</a></td></tr></table></td> </tr> </table></td> </tr></table></td> </tr> </table><br/>";
                featuredboxlbl.ID = "FeaturedBoxLbl" + i.ToString();
                PlaceHolder1.Controls.Add(featuredboxlbl);
            }

        }
            //handing th exceptions
        catch (SqlException sqex)
        {
            Label1.Text = sqex.Message;
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}