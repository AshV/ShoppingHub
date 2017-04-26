using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;          //using required namespace for connecting database
using System.Data.SqlClient;    //using required namespace for connecting database
using System.Configuration;     //using required namespace for connecting database

public partial class admin_AddNewBrand : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();  //Making Connection Object
    protected void Page_Load(object sender, EventArgs e)
    {
        //Redirecting to AdminLogin Page if Admin is not Logged In
        if (Session["Admin"] == null || Session["Admin"] == "")
        {
            Response.Redirect("AdminLogin.aspx");
        }
        //Executing Procedure 'brandidautogen' for AutoGenerating Brand ID
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString;
        string str = "exec brandidautogen";
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        DataSet ds = new DataSet();
        DataRow dr;
        con.Open();
        da.Fill(ds, "#top");
        con.Close();
        dr = ds.Tables["#top"].Rows[0];
        TextBox1.Text = dr["var"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Executing Procedure 'insprod' for inserting into Database
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "insbrand";
        string logo = "img/brandimg/noimg.jpg";
        //Checking if file upload control has file or not
        if (FileUpload1.HasFile)
        {
            string d = (System.IO.Path.GetExtension(FileUpload1.FileName)).ToLower();
            //validating filetype 
            if (d == ".jpg" || d == ".jpeg" || d == ".png")
            {
                string path = "~/img/brandimg/";
                string path2 = Server.MapPath(path);
                string f = Convert.ToString(DateTime.Now.GetHashCode()) + d;
                FileUpload1.SaveAs(path2 + f);
                logo = "img/brandimg/" + f;
            }
        }
        cmd.Parameters.AddWithValue("@brandid",Convert.ToInt32(TextBox1.Text));
        cmd.Parameters.AddWithValue("@brandname",TextBox2.Text.Trim());
        cmd.Parameters.AddWithValue("@logo",logo);
        cmd.Parameters.AddWithValue("@description",TextBox3.Text.Trim());
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("AddNewBrand.aspx");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
            //Handling Exceptions
        catch (SqlException ex)
        {
            Label5.Text = ex.Message;
        }
        catch (Exception ex1)
        {
            Label5.Text = ex1.Message;
        }
    }
}