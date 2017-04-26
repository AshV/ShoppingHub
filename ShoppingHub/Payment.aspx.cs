using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;              //using required namespace for connecting to database
using System.Data.SqlClient;    //using required namespace for connecting to database
using System.Configuration;     //using required namespace for connecting to database

public partial class Payment : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();        //Making Connection Object
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString;    //establishing connection to database
        //checking is user is logged in
        if ((Session["uid"] == "") || (Session["uid"] == null))
        {
            //if user is not logged in redirected to Sign Up Page
            Response.Redirect("Signup.aspx");
        }
        else
        {
            //if user is logged in creating menu accordingly
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
        try
        {
            //Executing Procedure 'makeorder' for inserting values to Order Table
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "makeorder";
            cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Session["uid"]));
            cmd.Parameters.AddWithValue("@address", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@payoption", RadioButtonList1.Text);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //forwarding detail to paypal for making Payment
            Response.Redirect("http://paypal.com?id=XXXXpayoption=XXX");
        }
            //Handling Exceptions
        catch(SqlException ex)
        {
            Label4.Text=ex.Message;
        }
        catch(Exception ex1)
        {
            Label4.Text = ex1.Message;
        }
    }
}