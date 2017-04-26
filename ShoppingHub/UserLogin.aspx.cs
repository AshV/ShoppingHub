using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;              //using required namespace for Connecting to database
using System.Data.SqlClient;    //using required namespace for Connecting to database
using System.Configuration;     //using required namespace for Connecting to database

public partial class SignIn : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();            //Making Connection Object
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString;    //connecting to database via global connection string
        //Checking if user is logged in
        if ((Session["uid"] == "") || (Session["uid"] == null))
        {
            //UserMenu if user not logged in
            Label userMenu = new Label();
            userMenu.Text = "<ul class='links'><li class='bold first'>Welcome Guest!</li><li><a href='SignUp.aspx'>My Account</a></li><li><a href='SignUp.aspx'>My Wishlist</a></li><li><a href='SignUp.aspx'>My Cart</a></li><li><a href='SignUp.aspx'>Checkout</a></li><li><a href='UserLogin.aspx'>Log In</a></li></ul>";
            userMenu.ID = "userMenu";
            PlaceHolder1.Controls.Add(userMenu);
        }
        else
        {
            //UserMenu if user in logged in ,no need to sign up,Redirected to HomePage
            Response.Redirect("Default.aspx");
        }
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        //executing procedure 'loginpro' for Logging in
        string str = "exec loginpro '"+Login1.UserName+"','"+Login1.Password+"'";
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        DataSet ds = new DataSet();
        DataRow dr;
        try
        {
            con.Open();
            da.Fill(ds,"#temp");
            con.Close();
            dr = ds.Tables["#temp"].Rows[0];
            int a = Convert.ToInt32(dr["var"]);
            if (a == 1)
            {
                string str1 = "select uid from useracc where email='" + Login1.UserName.ToString() + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(str1, con);
                DataSet ds1 = new DataSet();
                DataRow dr1;
                con.Open();
                da1.Fill(ds1, "uid");
                con.Close();
                dr1 = ds1.Tables["uid"].Rows[0];
                //placing uid to session variable if login is successfull
                Session["uid"] = Convert.ToInt32(dr1["uid"]);
                Response.Redirect("Default.aspx");
            }
            else
            {
                //Showing message if Login fails
                Login1.FailureText = "Invalid Password !";
            }
        }
            //Handling Exceptions
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