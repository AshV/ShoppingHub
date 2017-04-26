using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RemoveFromCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> ls = (List<string>)Application.Get("Cart");
        string removeProd = Request.QueryString["removeProdID"];
        ls.Remove(removeProd);
        Response.Redirect("Cart.aspx");
    }
}