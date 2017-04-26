using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;      //using required namespace for connecting database
using System.Data.SqlClient;    //using required namespace for connecting database
using System.Configuration;     //using required namespace for connecting database
using System.Web.UI.WebControls;

public partial class admin_AddNewProduct : System.Web.UI.Page
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
        string str = "exec prodidautogen";
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        DataSet ds = new DataSet();
        DataRow dr;
        con.Open();
        da.Fill(ds,"#top");
        con.Close();
        dr = ds.Tables["#top"].Rows[0];
        TextBox1.Text = dr["var"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Executing Procedure 'insprod' for inserting into Database
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "insprod";
        Label13.Text = "No";
        //Checking if file upload control has file or not
        if (FileUpload1.HasFile)
        {
            string d = (System.IO.Path.GetExtension(FileUpload1.FileName)).ToLower();
            //validating filetype 
            if (d == ".jpg" || d == ".jpeg" || d == ".png")
            {
                string path = "~/img/prodimg/";
                string path2 = Server.MapPath(path);
                string f = Convert.ToString(DateTime.Now.GetHashCode()) + d;
                FileUpload1.SaveAs(path2 + f);
                Label12.Text = "img/prodimg/" + f;
            }
        }
        cmd.Parameters.AddWithValue("@prodid",Convert.ToInt32(TextBox1.Text));
        cmd.Parameters.AddWithValue("@catid",Convert.ToInt32(DropDownList1.SelectedValue));
        cmd.Parameters.AddWithValue("@prodname",TextBox2.Text.Trim());
        cmd.Parameters.AddWithValue("@purprice",TextBox3.Text.Trim());
        cmd.Parameters.AddWithValue("@saleprice",TextBox4.Text.Trim());
        cmd.Parameters.AddWithValue("@brandid",Convert.ToInt32(DropDownList2.SelectedValue));
        cmd.Parameters.AddWithValue("@brandimg", Label12.Text);
        cmd.Parameters.AddWithValue("@active",RadioButtonList1.Text);
        cmd.Parameters.AddWithValue("@avail",RadioButtonList2.Text);
        cmd.Parameters.AddWithValue("@description",TextBox5.Text.Trim());
        cmd.Parameters.AddWithValue("@featured", Label13.Text);
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("AddNewProduct.aspx");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }
        //Handling Exceptions
        catch (SqlException ex)
        {
            Label11.Text = ex.Message;
        }
        catch (Exception ex1)
        {
            Label11.Text = ex1.Message;
        }
    }
}