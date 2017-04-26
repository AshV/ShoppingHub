using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Redirecting To Admin Login Page if Admin is not Logged In
        if (Session["Admin"] == null || Session["Admin"] == "")
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
}