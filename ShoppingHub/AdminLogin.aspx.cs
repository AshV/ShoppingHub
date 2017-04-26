using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;          //using required namespace for connecting database
using System.Data.SqlClient;    //using required namespace for connecting database
using System.Configuration;     //using required namespace for connecting database

public partial class admLogin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();    //Making Connection Object
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString;    //Connecting toDatabase via global connectionstring
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        //Executing Stored Procedure 'admloginpro' for Administrator Logging In
        string str="exec admloginpro '"+Login1.UserName+"','"+Login1.Password+"'";
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        DataSet ds = new DataSet();
        DataRow dr;
        try
        {
            con.Open();
            da.Fill(ds, "#temp");
            con.Close();
            dr = ds.Tables["#temp"].Rows[0];
            int a = Convert.ToInt32(dr["var"]);
            if (a == 1)
            {
                Session["Admin"] = Login1.UserName.ToString();
                Response.Redirect("AdminHome.aspx");
            }
            else
            {
                Login1.FailureText = "Invalid Password";
            }
        }
            //Handling Exception
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