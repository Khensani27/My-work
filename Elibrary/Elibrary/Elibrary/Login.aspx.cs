using Elibrary.Controllers;
using Elibrary.Models;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elibrary
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["User"] = "";
        }

        protected async void login_Click(object sender, EventArgs e)
        {
           
            lblMessage.Text = "";
            lblMessage.Style["display"] = "none";

            string strPassword = password.Text;
            string strEmail = email.Text;

            // I am checking if the login is Admin or what.
            if (strEmail == "Admin@gmail.com" && strPassword == "Kay0001#")
            {
                Session["Admin"] = "Admin";
                Response.Redirect("Admin_Home_Page.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                // Normal user login:
                UserController auth = new UserController();
                Users user = await auth.logIn("User/getUser?email=" + strEmail + "&password=" + strPassword);

                if (user != null)
                {
                    Session["User"] = (user.Id).ToString();

                    // Check if the account is still pending
                    if (user.Account_Status == "pending")
                    {
                        lblMessage.Text = "Your account is still pending approval. Please wait until it is approved.";
                        lblMessage.CssClass = "alert alert-warning";
                        lblMessage.Style["display"] = "block"; // Show the message
                    }
                    else
                    {
                        
                        password.Text = "";
                        email.Text = "";

                       
                        Response.Redirect("Member_Home.aspx");
                    }
                }
                else
                {
                    // Displaying error message for invalid login.
                    lblMessage.Text = "Invalid email or password. Please try again.";
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Style["display"] = "block"; // Show the message
                }
            }
        }
    }
}
