using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;   //using required namespace for connecting database
using System.Data.SqlClient;     //using required namespace for connecting database
using System.Configuration;  //using required namespace for connecting database

public partial class admin_Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Redirecting to AdminLogin Page if Admin is not Logged In
        if (Session["Admin"] == null || Session["Admin"] == "")
        {
            Response.Redirect("AdminLogin.aspx");
        }
        //Executing Procedure 'catidautogen' for AutoGenerating Category ID
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString;
        string str = "exec catidautogen";
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        DataSet ds = new DataSet();
        DataRow dr;
        con.Open();
            da.Fill(ds,"#top");
        con.Close();
        dr=ds.Tables["#top"].Rows[0];
        TextBox1.Text=dr["var"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Executing Procedure 'inscat' for inserting into Database
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "inscat";
        Label6.Text = "<a href='Browse.aspx?cat="+TextBox1.Text.Trim()+"'>"+TextBox2.Text.Trim()+"</a>";
        //Checking if file upload control has file or not
        if (FileUpload1.HasFile)
        {
            string d = (System.IO.Path.GetExtension(FileUpload1.FileName)).ToLower();
            //validating filetype 
            if (d == ".jpg" || d == ".jpeg" || d == ".png")
            {
                string path = "~/img/catimg/";
                string path2 = Server.MapPath(path);
                string f=Convert.ToString(DateTime.Now.GetHashCode()) + d;
                FileUpload1.SaveAs(path2 +f);
                Label7.Text = "img/catimg/" + f;
            }
        }
        cmd.Parameters.AddWithValue("@catid", Convert.ToInt32(TextBox1.Text.Trim()));
        cmd.Parameters.AddWithValue("@catname", TextBox2.Text.Trim());
        string ctnm = TextBox2.Text.Trim();
        cmd.Parameters.AddWithValue("@catlink",Label6.Text);
        cmd.Parameters.AddWithValue("@catimg",Label7.Text);
        cmd.Parameters.AddWithValue("@active", RadioButtonList1.Text);
        cmd.Parameters.AddWithValue("@description", TextBox3.Text);
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("AddNewCategory.aspx");
            TextBox2.Text = "";
            TextBox3.Text = "";
            Label8.Text = ctnm + " Successfully Added!";
        }
        //Handling Exceptions
        catch (SqlException ex)
        {
            Label8.Text = "Error:" + ex.Message;
        }
        catch (Exception ex1)
        {
            Label8.Text = ex1.Message;
        }
    }
}