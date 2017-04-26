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

public partial class Browse : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();    //creating connection object
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString;    //creating connection to database
        string catid = Request.QueryString["cat"];  //retrieving category id from querystring to show product of that category in page
        string[] dyt = new string[5];
        //Checking if No user is logged in and Showing User menu according to user state
        if ((Session["uid"] == "") || (Session["uid"] == null))
        {
            //dynamically creating user menu if user is not logged in
            Label userMenu = new Label();
            userMenu.Text = "<ul class='links'><li class='bold first'>Welcome Guest!</li><li><a href='SignUp.aspx'>My Account</a></li><li><a href='SignUp.aspx'>My Wishlist</a></li><li><a href='SignUp.aspx'>My Cart</a></li><li><a href='SignUp.aspx'>Checkout</a></li><li><a href='UserLogin.aspx'>Log In</a></li></ul>";
            userMenu.ID = "userMenu";
            PlaceHolder2.Controls.Add(userMenu);
        }
        else
        {
            //retrieving user's name according session uid is user is logged in
            string usr = "select fname from useracc where uid='" + Convert.ToInt32(Session["uid"]) + "'";
            SqlDataAdapter da2 = new SqlDataAdapter(usr, con);
            DataSet ds2 = new DataSet();
            DataRow dr2;
            con.Open();
            da2.Fill(ds2, "name");
            con.Close();
            dr2 = ds2.Tables["name"].Rows[0];
            string nm = Convert.ToString(dr2["fname"]);
            //dynamically creating user menu if user is logged in
            Label userMenu = new Label();
            userMenu.Text = "<ul class='links'><li class='bold first'>Welcome " + nm + "!</li><li><a href='UserHome.aspx'>My Account</a></li><li><a href='Wishlist.aspx'>My Wishlist</a></li><li><a href='Cart.aspx'>My Cart</a></li><li><a href='Payment.aspx'>Checkout</a></li><li><a href='LogOut.aspx'>Log Out</a></li></ul>";
            userMenu.ID = "userMenu";
            PlaceHolder2.Controls.Add(userMenu);
        }
        try
        {
            //retrieving all the product of category which is passed through querystring
            string str = "select prodid,prodname,saleprice,brandimg from prodtab where catid='"+catid+"'";
            SqlDataAdapter da = new SqlDataAdapter(str,con);
            DataSet ds = new DataSet();
            DataRow dr;
            con.Open();
            da.Fill(ds,"product");
            con.Close();
            for (int k = 0; k < ds.Tables["product"].Rows.Count; k++)
            {
                for (int j = 0; j < ds.Tables["product"].Rows.Count; j++)
                {
                    dr = ds.Tables["product"].Rows[k];
                    dyt[j] = Convert.ToString(dr[j]);
                }
                Label singleprod = new Label();
                //creating product tab dynamically within div tag which are flotted left
                singleprod.Text = "<div style='float:left;'><table width='170px' height='250px' id='singleprodcantainer'><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dyt[0] + "'><img src=" + dyt[3] + " /></a></td></tr><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dyt[0] + "'>" + dyt[1] + "</a></td></tr><tr><td align='center'><a href='WishList.aspx?prodid=" + dyt[0] + "'><img src='img/addtowishlist.gif' alt='Add Product To WishList' /></a></td></tr><tr><td align='center'><a href='Cart.aspx?prodid=" + dyt[0] + "'><img src='img/addtocart.gif' alt='Add Product To Cart' /></a></td></tr><tr><td align='center'><a href='ProdDetails.aspx?prodid=" + dyt[0] + "'>Rs." + dyt[2] + "</a></td></tr></table></div>";
                singleprod.ID = "SingleProduct" + k.ToString();
                PlaceHolder1.Controls.Add(singleprod);
            }

        }
            //handling exception
        catch (SqlException ex)
        {
            Label1.Text = ex.Message;
        }
        catch (Exception ex1)
        {
            Label1.Text = ex1.Message;
        }
    }
}