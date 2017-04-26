using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;              //using required namespace for connecting database
using System.Data.SqlClient;    //using required namespace for connecting database
using System.Configuration;     //using required namespace for connecting database

public partial class ContactUs : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();       //Making Conection Object
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString; //connecting to database via global connection string
        //Checking if User is Logged In
        if ((Session["uid"] == "") || (Session["uid"] == null))
        {
            //creating userMenu if user is not logged in
            Label userMenu = new Label();
            userMenu.Text = "<ul class='links'><li class='bold first'>Welcome Guest!</li><li><a href='SignUp.aspx'>My Account</a></li><li><a href='SignUp.aspx'>My Wishlist</a></li><li><a href='SignUp.aspx'>My Cart</a></li><li><a href='SignUp.aspx'>Checkout</a></li><li><a href='UserLogin.aspx'>Log In</a></li></ul>";
            userMenu.ID = "userMenu";
            PlaceHolder2.Controls.Add(userMenu);
        }
        else
        {
            //creating UserMenu if user in Logged in
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
        //Executing Procedure 'insqry' for inserting values to database
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "insqry";
        cmd.Parameters.AddWithValue("@nm",TextBox1.Text.Trim());
        cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
        cmd.Parameters.AddWithValue("@qry",TextBox3.Text.Trim());
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("ContactUs.aspx");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
            //Handling exception
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