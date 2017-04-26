using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;              //Using Required namespace
using System.Data.SqlClient;    //Using Required namespace
using System.Configuration;     //Using Required namespace

public partial class ChangePassword : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();        //Making Connection Object
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString;    //establishing connection to database
        //Checking if No user is logged in and Showing User menu according to user state
        if ((Session["uid"] == "") || (Session["uid"] == null))
        {
            //Usermenu if User is not logged in
            Label userMenu = new Label();
            userMenu.Text = "<ul class='links'><li class='bold first'>Welcome Guest!</li><li><a href='SignUp.aspx'>My Account</a></li><li><a href='SignUp.aspx'>My Wishlist</a></li><li><a href='SignUp.aspx'>My Cart</a></li><li><a href='SignUp.aspx'>Checkout</a></li><li><a href='UserLogin.aspx'>Log In</a></li></ul>";
            userMenu.ID = "userMenu";
            PlaceHolder2.Controls.Add(userMenu);
        }
        else
        {
            //user menu if usaer in logged in
            //retriving user name if user is logged in
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
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //Executing Procedure chpwd to change password
        string str = "exec chpwd '"+Convert.ToInt32(Session["uid"])+"','"+TextBox1.Text+"','"+TextBox3.Text+"'";
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        DataSet ds=new DataSet();
        DataRow dr;
        con.Open();
        da.Fill(ds,"#temp");
        con.Close();
        dr = ds.Tables["#temp"].Rows[0];
        //Getting message via flag variable a
        int a = Convert.ToInt32(dr["var"]);
        if (a == 1)
        {
            //if flag is 1 then password is changed
            Label1.Text = "Password Changed!";
        }
        else
        {
            //if flag is 0 then password is not changed
            Label1.Text = "Password Not Changed!";
        }
    }
}