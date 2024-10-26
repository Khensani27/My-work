using Elibrary.Controllers;
using Elibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elibrary
{
    public partial class userprofile : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                // string userId= Session["User"] as string;
                 string userId= (string)Session["User"];
                // Check if a user is logged in (session is not null)
                if (userId != null)
                {
                    // Retrieve the user object from the session
                    //Users user = (Users)Session["User"];
                   
                    UserController auth = new UserController();
                    Users user = await auth.logIn("User/getUserByID?id="+userId);

               

                    // Populate the profile fields
                    lblFirstName.Text = user.First_Name;
                    lblLastName.Text = user.Last_Name;
                    lblNumber.Text = user.Contact_No;
                    lblEmail.Text = user.Email;
                    lblAddress.Text = user.Address;
                    Label1.Text = user.Account_Status; 
                    TextBox8.Text = user.Id.ToString();
                }
                else
                {
                   
                    Response.Redirect("Login.aspx");
                }
            }
        }


        protected void Update_Click(object sender, EventArgs e)
        {
            string userId = (string)Session["User"];

            if (!string.IsNullOrEmpty(userId))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string query = "UPDATE Users SET First_Name = @FirstName,Password = @Password, Last_Name = @LastName, Contact_No = @ContactNo, Email = @Email, Address = @Address WHERE Id = @UserID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Bind parameters for updating user details
                        cmd.Parameters.AddWithValue("@FirstName", lblFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", lblLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactNo", lblNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", lblEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", lblAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", lblPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Successfully updated the user
                            lblMessage.Text = "Profile updated successfully.";
                            lblMessage.CssClass = "alert alert-success";
                            lblMessage.Style["display"] = "block"; // Show the message
                        }
                        else
                        {
                            // Failed to update the user
                            lblMessage.Text = "Error updating profile details.";
                            lblMessage.CssClass = "alert alert-danger";
                            lblMessage.Style["display"] = "block"; // Show the message
                        }
                    }
                }
            }
            else
            {
                lblMessage.Text = "User ID not found.";
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Style["display"] = "block"; // Show the message
            }
        }


        private void ClearFields()
        {
            lblFirstName.Text = "";
            lblLastName.Text = "";
            lblNumber.Text = "";
            lblEmail.Text = "";
            lblAddress.Text = "";
            Label1.Text = "";
            lblMessage.Text = "";
            lblPassword.Text = "";
        }

    }
}