using Elibrary.Controllers;
using Elibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elibrary
{
    public partial class Admin_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected async void login_Click(object sender, EventArgs e)
        {
            // Clear any previous error messages
            lblMessage.Text = "";
            lblMessage.Style["display"] = "none";

            string strPassword = password.Text;
            string strEmail = email.Text;

            AdminController auth = new AdminController();
            Admins admin = await auth.logIn("Admin/getAdmin?email=KayN&password=Kay0001%23");
            


            if (admin != null & strPassword=="Kay0001#" & strEmail=="KayN")
            {
                

                    // Clear the textboxes
                    password.Text = "";
                    email.Text = "";

                    // Redirect to the home page
                    Response.Redirect("Admin_Home_Page.aspx");
                }
               
            else
            {
                // Display error message
                lblMessage.Text = "Invalid email or password. Please try again.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Style["display"] = "block"; // Show the message
            }
        }
    }
}