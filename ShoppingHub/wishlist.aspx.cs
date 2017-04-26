using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;              //Using required namespace
using System.Data.SqlClient;    //Using required namespace
using System.Configuration;     //Using required namespace

public partial class wishlist : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();        //Making Connection Object
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString;    //Connecting to database via global connection string
            //Checking if User is logged in
            if ((Session["uid"] == "") || (Session["uid"] == null))
            {
                //if User is not logged in redirected to Sign Up Page
                Response.Redirect("SignUp.aspx");
            }
            else
            {
                //if User is logged in Showing Menu According
                string usr = "select fname from useracc where uid='" + Convert.ToInt32(Session["uid"]) + "'";
                SqlDataAdapter da5 = new SqlDataAdapter(usr, con);
                DataSet ds5 = new DataSet();
                DataRow dr5;
                con.Open();
                da5.Fill(ds5, "name");
                con.Close();
                dr5 = ds5.Tables["name"].Rows[0];
                string nm = Convert.ToString(dr5["fname"]);
                Label userMenu = new Label();
                userMenu.Text = "<ul class='links'><li class='bold first'>Welcome " + nm + "!</li><li><a href='UserHome.aspx'>My Account</a></li><li><a href='Wishlist.aspx'>My Wishlist</a></li><li><a href='Cart.aspx'>My Cart</a></li><li><a href='Payment.aspx'>Checkout</a></li><li><a href='LogOut.aspx'>Log Out</a></li></ul>";
                userMenu.ID = "userMenu";
                PlaceHolder2.Controls.Add(userMenu);
                //Checking if Product ID is passed via query string or not
                if (Request.QueryString["prodid"] == "" || Request.QueryString["prodid"] == null)
                {
                    //if product id is not passed via query string then it shows already existed Products
                    int prodid = Convert.ToInt32(Request.QueryString["prodid"]);
                    //retrieving all product id from wishlist table according to uid passed in session
                    string str2 = "select prodid,datead from wishlist where uid='"+Convert.ToInt32(Session["uid"])+"'";
                    SqlDataAdapter da2 = new SqlDataAdapter(str2, con);
                    DataSet ds2 = new DataSet();
                    DataRow dr2;
                    con.Open();
                    da2.Fill(ds2, "prodlist");
                    con.Close();
                    for (int i = 0; i < ds2.Tables["prodlist"].Rows.Count; i++)
                    {
                        //retrieving Product details from product table accroding to uid retrieved from last query
                        dr2 = ds2.Tables["prodlist"].Rows[i];
                        int pid=Convert.ToInt32(dr2["prodid"]);
                        string dt = Convert.ToString(dr2["datead"]);
                        string str3 = "select prodname,saleprice,brandimg from prodtab where prodid='"+pid+"'";
                        SqlDataAdapter da3= new SqlDataAdapter(str3,con);
                        DataSet ds3= new DataSet();
                        DataRow dr3;
                        con.Open();
                        da3.Fill(ds3,"wlist");
                        con.Close();
                        for (int j = 0; j < ds3.Tables["wlist"].Rows.Count; j++)
                        {
                            dr3 = ds3.Tables["wlist"].Rows[j];
                            string pnm = Convert.ToString(dr3["prodname"]);
                            string price = Convert.ToString(dr3["saleprice"]);
                            string img = Convert.ToString(dr3["brandimg"]);
                            //Dynamically Showing already exised Content of wishlist 
                            Label prod = new Label();
                            prod.Text = "<table align='center' border='1' width='100%'><tr><td><img src='"+img+"'/></td><td>"+pnm+"</td><td>"+price+"</td></tr></table><br/>";
                            PlaceHolder1.Controls.Add(prod);
                        }
                    }
                }
                else
                {
                    //iF Product ID is passed via query string then it is added to WIshlist table with uid passed via Session 
                    int prodid = Convert.ToInt32(Request.QueryString["prodid"]);
                    //Procedure for auto Generating Wishlist ID
                    string str = "exec wlidautogen";
                    SqlDataAdapter da = new SqlDataAdapter(str, con);
                    DataSet ds = new DataSet();
                    DataRow dr;
                    con.Open();
                    da.Fill(ds, "#top");
                    con.Close();
                    dr = ds.Tables["#top"].Rows[0];
                    int wlid = Convert.ToInt32(dr["var"]);
                    int uid = Convert.ToInt32(Session["uid"]);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Procedure for inserting values to wishlist table
                    cmd.CommandText = "addtowishlist";
                    cmd.Parameters.AddWithValue("@wlid", wlid);
                    cmd.Parameters.AddWithValue("@uid", uid);
                    cmd.Parameters.AddWithValue("@prodid", prodid);
                    cmd.Parameters.AddWithValue("@datead", Convert.ToString(DateTime.Now));
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //query for showing details of product which is added to wishlist
                    string str2 = "select prodname,saleprice,brandimg from prodtab where prodid='" + prodid + "'";
                    SqlDataAdapter da2 = new SqlDataAdapter(str2, con);
                    DataSet ds2 = new DataSet();
                    DataRow dr2;
                    con.Open();
                    da2.Fill(ds2, "AddProd");
                    con.Close();
                    dr2 = ds2.Tables["AddProd"].Rows[0];
                    string prodname = Convert.ToString(dr2["prodname"]);
                    string saleprice = Convert.ToString(dr2["saleprice"]);
                    string img = Convert.ToString(dr2["brandimg"]);
                    //Showing Currently added content in dynamically generated table
                    Label cartItem = new Label();
                    cartItem.Text = "<table width='100%' align='center' border='1'><tr><td><table align='center'><tr><td rowspan='2'><img src='" + img + "'/></td><td>" + prodname + "</td><td rowspan='2'>Prod</td><td rowspan='2'><a href='RemoveFromCart.aspx?removeProdID=" + prodid + "'>Remove From Cart</a></td></tr><tr><td>" + saleprice + "</td></tr></table></td></tr></table>";
                    PlaceHolder1.Controls.Add(cartItem);
                    Label1.Text = prodname + " SuccessFully Added To Cart !";
                }
            }
        }
            //Handling Exceptions
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