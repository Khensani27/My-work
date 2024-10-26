using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using FinalYearWeb.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalYearWeb.Security;

namespace FinalYearWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["U_ID"] = "";
            //Response.Redirect("Login.aspx");
        }

        protected async void login_Click(object sender, EventArgs e)
        {

            string strPassword = password.Text;
            string strEmail = email.Text;
            Authentication auth = new Authentication();
            Users user = await auth.logIn("User/getUser?email=" + strEmail + "&password=" + strPassword);

            if (Session["JustLogin"] != null)
            {
                if (user != null)
                {
                    Session["U_ID"] = user.U_ID.ToString();
                    string tocartName = Request.QueryString["name"].ToString();
                    string tocartDescription = Request.QueryString["description"].ToString();
                    string tocartPrice = Request.QueryString["price"].ToString();
                    string tocartUrl = Request.QueryString["url"].ToString();
                    string tocartId = Request.QueryString["F_id"].ToString();
                    string tocartCategory = Request.QueryString["category"].ToString(); 
                    string tocartQuantity = Request.QueryString["quantity"].ToString();

                    if (user.U_type.Equals("customer"))
                    {
                        Response.Redirect("Cart.aspx?name=" + tocartName + "&url=" + tocartUrl + "&price=" + tocartPrice + "&description=" + tocartDescription + "&F_id=" + tocartId+ "&category=" + tocartCategory + "&quantity=" + tocartQuantity + "&UserID="+ user.U_ID);  /// was about to add string parameters(query string)
                    }
                   

                }
                else
                {
                    LblLogin.Text = "Incorrect email or password";
                    LblLogin.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                if (user != null)
                {
                    if (user.U_type.Equals("Student") || user.U_type.Equals("UJ Staff"))
                    {
                        Session["CustomerLogin"] = user.U_ID.ToString();
                        Session["U_ID"] = user.U_ID.ToString();
                        Response.Redirect("CustomerHome.aspx?U_ID=" + user.U_ID + "&U_Type=" +user.U_type);
                    }
                    if (user.U_type.Equals("runner"))
                    {
                        Response.Redirect("Runner.aspx");
                    }
                    if (user.U_type.Equals("manager"))
                    {
                        Response.Redirect("ManagerHome.aspx");
                    }
                    if (user.U_type.Equals("kitchen staff"))
                    {
                        Response.Redirect("KitchenStaff.aspx");
                    }

                }
                else
                {
                    LblLogin.Text = "Incorrect email or password";
                    LblLogin.ForeColor = System.Drawing.Color.Red;
                }
            }
            
        }
    }
}