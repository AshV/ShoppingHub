using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;              //using required namespace for connecting database 
using System.Data.SqlClient;    //using required namespace for connecting database
using System.Configuration;     //using required namespace for connecting database

public partial class user_AddNewUser : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();            //Making Connection Object
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString; //Connecting to database via global connectioo string
        //Checking User State
        if ((Session["uid"] == "") || (Session["uid"] == null))
        {
            //Showing user menu if User is not logged in
            Label userMenu = new Label();
            userMenu.Text = "<ul class='links'><li class='bold first'>Welcome Guest!</li><li><a href='SignUp.aspx'>My Account</a></li><li><a href='SignUp.aspx'>My Wishlist</a></li><li><a href='SignUp.aspx'>My Cart</a></li><li><a href='SignUp.aspx'>Checkout</a></li><li><a href='UserLogin.aspx'>Log In</a></li></ul>";
            userMenu.ID = "userMenu";
            PlaceHolder1.Controls.Add(userMenu);
        }
        else
        {
            //if user is already logged in he/she dosen't need to sign up so redirect to HomePage   
            Response.Redirect("Default.aspx");
        }
        //Executing Stored procedure for auto generating user id so they will be unique
        string str = "exec useridautogen";
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        DataSet ds = new DataSet();
        DataRow dr;
        con.Open();
        da.Fill(ds,"#top");
        con.Close();
        dr = ds.Tables["#top"].Rows[0];
        TextBox1.Text = dr["var"].ToString();   //putting auto generated uid to textbox1 which is read only
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            //executing stored procedure for inserting credentials to database 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usrsignup";
            cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(TextBox1.Text)); //assigning values to stored procedure for inserting in database
            cmd.Parameters.AddWithValue("@email", TextBox3.Text.Trim());          //assigning values to stored procedure for inserting in database
            cmd.Parameters.AddWithValue("pwd", TextBox4.Text.Trim());              //assigning values to stored procedure for inserting in database  
            cmd.Parameters.AddWithValue("@status", "Yes");                       //assigning values to stored procedure for inserting in database
            cmd.Parameters.AddWithValue("@fname", TextBox2.Text.Trim());         //assigning values to stored procedure for inserting in database
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Session["uid"] = TextBox1.Text.Trim();
            Response.Redirect("Default.aspx");
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }
            //handling exceptions
        catch (SqlException ex)
        {
            Label4.Text = ex.Message;
        }
        catch (Exception ex1)
        {
            Label4.Text = ex1.Message;   
        }
    }
}