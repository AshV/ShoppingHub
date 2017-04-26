using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;                  //using required name space for database connection
using System.Data.SqlClient;         //using required name space for database connection
using System.Configuration;          //using required name space for database connection
using System.Web.UI.HtmlControls;

public partial class ProdDetails : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();                    //creating database connection object
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString;    //establishing connection to database
            string pid = Request.QueryString["prodid"]; //retrieving product id from querystring to show specific product details on page
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
            //retrieving product's detail from database according to product id passed from query string
            string str = "select prodname,saleprice,brandimg,description from prodtab where prodid='" + pid + "'";
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            DataRow dr;
            con.Open();
            da.Fill(ds, "prod");
            con.Close();
            dr = ds.Tables["prod"].Rows[0];
            string pname = Convert.ToString(dr[0]);
            string price = Convert.ToString(dr[1]);
            string img = Convert.ToString(dr[2]);
            string des = Convert.ToString(dr[3]);
             //arranging product details in dynamically created table retrieved from database
            Label pDetails = new Label();
            pDetails.Text = "<table width='100%'><tr><td colspan='2'></td></tr><tr><td colspan='2' align='center'><h5 class='small_head'>" + pname + "</h5></td></tr><tr><td rowspan='2' align='right'><img src=" + img + "/></td><td align='left'><h2>Rs." + price + "</h2></td></tr><tr><td align='left'><h2>" + des + "</h2></td></tr><tr><td align='right'><a href='Wishlist.aspx?prodid=" + pid + "'><img src='img/addtowishlist.gif' /></a></td><td align='left'><a href='Cart.aspx?prodid=" + pid + "'><img src='img/addtocart.gif' /></a></td></tr></table>";
            pDetails.ID = "ProductDetails";
            PlaceHolder1.Controls.Add(pDetails);
        }
            //handling exception
        catch(SqlException ex)
        {
            Label1.Text=ex.Message;
        }
        catch(Exception ex1)
        {
            Label1.Text = ex1.Message;
        }
    }
}