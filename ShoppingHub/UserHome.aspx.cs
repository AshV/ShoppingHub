using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;              //using required namespace
using System.Data.SqlClient;    //using required namespace
using System.Configuration;     //using required namespace

public partial class UserHome : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();        //Making Connection Object
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString; //connecting to database via global connectionstring
        //Checking User state if user is logged in
        if ((Session["uid"] == "") || (Session["uid"] == null))
        {
            //if user is not logged redirect to Sign Up Page
            Response.Redirect("SignUp.aspx");
        }
        else
        {
            //If User Is logged in showing Usermenu accordingly
            string usr = "select fname from useracc where uid='" + Convert.ToInt32(Session["uid"]) + "'";
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

            //Showing Welcome message with User Name
            Label uname = new Label();
            uname.Text = "Welcome " + nm + "!";
            uname.ID = "uname";
            PlaceHolder1.Controls.Add(uname);

            //Retrieving and Showing No. of items in Wishlist from database
            string str2 = "select count(uid) from wishlist where uid='"+Convert.ToInt32(Session["uid"])+"'";
            SqlDataAdapter da = new SqlDataAdapter(str2,con);
            DataSet ds = new DataSet();
            DataRow dr;
            con.Open();
            da.Fill(ds, "wilist");
            con.Close();
            dr=ds.Tables["wilist"].Rows[0];
            Label wilist = new Label();
            wilist.Text = "You Have "+Convert.ToString(dr[0])+" Items in Your Wishlist !";
            wilist.ID = "wilist";
            PlaceHolder3.Controls.Add(wilist);

            //Retrieving and Showing No. of items in Shopping Cart From Application State Variable
            List<string> ls=(List<string>)Application.Get("Cart");
            int c=Convert.ToInt32(ls.Count);
            Label cart = new Label();
            cart.Text = "You Have "+c+" Items in Your Cart !";
            cart.ID = "Cart";
            PlaceHolder4.Controls.Add(cart);

        }
        
    }
}