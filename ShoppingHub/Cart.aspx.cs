using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;                  //using required namespaces for database connectivity
using System.Data.SqlClient;        //using required namespaces for database connectivity
using System.Configuration;         //using required namespaces for database connectivity
using System.Web.UI.HtmlControls;

public partial class Cart : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();                //making connection object
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> ls = (List<string>)Application.Get("Cart");        //retrieving Application State variable 'Cart' from Global.asax to List ls
        int total = 0;                                                  //variable for storing total amount to pay
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingHubCS"].ConnectionString;    //connecting to database via connection string
        try
        {
            //making usermenu according to User State
            if (Session["uid"] != "" || Session != null)
            {
                //Usermenu is yser is logged in
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
            }
            else
            {
                //user menu if user is not logged in
                Label userMenu = new Label();
                userMenu.Text = "<ul class='links'><li class='bold first'>Welcome Guest!</li><li><a href='SignUp.aspx'>My Account</a></li><li><a href='SignUp.aspx'>My Wishlist</a></li><li><a href='SignUp.aspx'>My Cart</a></li><li><a href='SignUp.aspx'>Checkout</a></li><li><a href='UserLogin.aspx'>Log In</a></li></ul>";
                userMenu.ID = "userMenu";
                PlaceHolder2.Controls.Add(userMenu);
            }
            //Cheking id product id is passed with Query String
            if ((Request.QueryString["prodid"] == "") || (Request.QueryString["prodid"]) == null)
            {
                foreach(string p in ls)
                {
                    //if no Poduct rae added to cart Showing message that cart is Empty
                    if (p == null || p == "")
                    {
                        Label empt = new Label();
                        empt.Text = "Your Cart Is Empty";
                        PlaceHolder1.Controls.Add(empt);
                    }
                    else
                    {
                       //if no prduct id is Passed via query string and cart has products, then it Shows Items available in Cart
                            string str="select prodname,saleprice,brandimg from prodtab where prodid='"+p+"'";
                            SqlDataAdapter da=new SqlDataAdapter(str,con);
                            DataSet ds=new DataSet();
                            DataRow dr;
                            con.Open();
                            da.Fill(ds,"product");
                            con.Close();
                            dr = ds.Tables["product"].Rows[0];
                            string prodname = Convert.ToString(dr["prodname"]);
                            string saleprice = Convert.ToString(dr["saleprice"]);
                            string img = Convert.ToString(dr["brandimg"]);
                            Label cartItem = new Label();
                        //Listing Cart's Product in dynamically created table
                            cartItem.Text = "<table width='100%' align='center' border='1'><tr><td><table align='center'><tr><td rowspan='2'><img src='"+img+"'/></td><td>"+prodname+"</td><td rowspan='2'>Prod</td><td rowspan='2'><a href='RemoveFromCart.aspx?removeProdID="+p+"'>Remove From Cart</a></td></tr><tr><td>"+saleprice+"</td></tr></table></td></tr></table>";
                            PlaceHolder1.Controls.Add(cartItem);
                            total += Convert.ToInt32(saleprice);
                    }
                }
                //Showing Total Amount to Pay in dynamicallt created Label.
                Label Gtotal = new Label();
                Gtotal.Text = "<table width='100%'><tr><td><div align='center'>" + total + "</div></td></tr></table>";
                PlaceHolder3.Controls.Add(Gtotal);
                Application["Total"] = total;  //Copying Total AMount to Pay in Application State Variable 'Total'
            }
            else
            {
                //if Product id is passed via query string it is added to Shopping Cart
                string prodid = Convert.ToString(Request.QueryString["prodid"]);
                ls.Add(prodid);
                //Retriving Product Details from Database which is added to cart
                string str2 = "select prodname,saleprice,brandimg from prodtab where prodid='" +prodid+ "'";
                SqlDataAdapter da2 = new SqlDataAdapter(str2, con);
                DataSet ds2 = new DataSet();
                DataRow dr2;
                con.Open();
                da2.Fill(ds2,"AddProd");
                con.Close();
                dr2=ds2.Tables["AddProd"].Rows[0];
                string prodname = Convert.ToString(dr2["prodname"]);
                string saleprice = Convert.ToString(dr2["saleprice"]);
                string img = Convert.ToString(dr2["brandimg"]);
                Label cartItem = new Label();
                //Showing product detail which is retrieved from database and added to cart
                cartItem.Text = "<table width='100%' align='center' border='1'><tr><td><table align='center'><tr><td rowspan='2'><img src='" + img + "'/></td><td>" + prodname + "</td><td rowspan='2'>Prod</td><td rowspan='2'><a href='RemoveFromCart.aspx?removeProdID=" + prodid + "'>Remove From Cart</a></td></tr><tr><td>" + saleprice + "</td></tr></table></td></tr></table>";
                PlaceHolder1.Controls.Add(cartItem);
                Label1.Text =prodname+" SuccessFully Added To Cart !";
            }
           
        }
            //handling excedption
        catch(SqlException ex)
        {
            Label1.Text = ex.Message;
        }
        catch(Exception ex1)
        {
            Label1.Text = ex1.Message;
        }
    }
}