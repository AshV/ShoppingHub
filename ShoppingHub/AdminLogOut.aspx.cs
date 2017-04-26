using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLogOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Admin"] = ""; 
        Session["Admin"] = null;
        Session.Abandon();  //Destroying Session
        Response.Redirect("AdminLogin.aspx"); //Redirecting to Admin Login Page
    }
}