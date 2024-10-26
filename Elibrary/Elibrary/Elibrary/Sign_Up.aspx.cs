using Elibrary.Controllers;
using Elibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elibrary
{
    public partial class Sign_Up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected async void Register_Click(object sender, EventArgs e)
        {
            UserController auth = new UserController();
            string email = txtEmailAddress.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtPassword1.Text; // Assuming TextBox8 is for Confirm Password

            // Check if the email already exists
            bool emailExists = await auth.DoesEmailExist(email);
            if (emailExists)
            {
                lblMessage.Text = "Email address already exists. Please use a different email.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Style["display"] = "block"; // Show the message
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match. Please try again.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Style["display"] = "block"; // Show the message
                return;
            }

            // Proceed with registration if the email does not exist and passwords match
            Users user = new Users()
            {
                First_Name = txtFirstName.Text,
                Last_Name = txtLastName.Text,
                Contact_No = txtNumber.Text,
                Email = email,
                Address = txtAddess.Text,
                Password = password, // Use password field here
                Account_Status = "pending",
            };

            HttpResponseMessage response = await auth.register("User/addUser", user);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    lblMessage.Text = "Registration successful. <a href='Login.aspx'>Click here to login</a>";
                    lblMessage.CssClass = "alert alert-success";
                    lblMessage.Style["display"] = "block"; // Show the message
                    ClearFields();
                }
                else
                {
                    lblMessage.Text = "Registration failed. Please try again.";
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Style["display"] = "block"; // Show the message
                }
            }
            else
            {
                lblMessage.Text = "Registration failed. Please try again.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Style["display"] = "block"; // Show the message
            }
        }

        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNumber.Text = "";
            txtEmailAddress.Text = "";
            txtAddess.Text = "";
            txtPassword.Text = "";
            txtPassword1.Text = ""; // Clear Confirm Password field
        }





    }
}