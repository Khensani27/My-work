using System;
using System.Web.UI;

namespace WebApplication3
{
    public partial class Site1 : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the current page's filename
            string currentPage = System.IO.Path.GetFileName(Request.Path);

            // Show Login and Sign-up buttons only on Home.aspx
            if (currentPage == "Home.aspx")
            {
                LinkButton1.Visible = true;
                LinkButton3.Visible = true;
                HomeButton.Visible = false;    // Hide Member Home button on the home page
                AdminHomeButton.Visible = false; // Hide Admin Home button on the home page
            }
            // Show the Member Home button only on Member_Profile.aspx, Book_Store.aspx, Books_History.aspx
            else if (currentPage == "Member_Profile.aspx" ||
                     currentPage == "Book_Store.aspx" ||
                     currentPage == "Books_History.aspx")
            {
                HomeButton.Visible = true;      // Show Member Home button
                AdminHomeButton.Visible = false; // Hide Admin Home button
                LinkButton1.Visible = false;
                LinkButton3.Visible = false;
            }
            // Show the Admin Home button only on admin-related pages
            else if (currentPage == "Member_Management.aspx" ||
                     currentPage == "Books_Page.aspx" ||
                     currentPage == "Book_Issuing_Page.aspx" ||
                     currentPage == "Payment.aspx" ||
                     currentPage == "Stats.aspx")
            {
                AdminHomeButton.Visible = true;  // Show Admin Home button
                HomeButton.Visible = false;      // Hide Member Home button
                LinkButton1.Visible = false;
                LinkButton3.Visible = false;
            }
            else
            {
                HomeButton.Visible = false;      // Hide Member Home button on all other pages
                AdminHomeButton.Visible = false; // Hide Admin Home button on all other pages
                LinkButton1.Visible = false;
                LinkButton3.Visible = false;
            }
        }

        // Handle the click event for the Member's Home button
        protected void HomeButton_Click(object sender, EventArgs e)
        {
            // Redirect the user to Member_Home.aspx
            Response.Redirect("Member_Home.aspx");
        }

        // Handle the click event for the Admin's Home button
        protected void AdminHomeButton_Click(object sender, EventArgs e)
        {
            // Redirect the admin to Admin_Home.aspx
            Response.Redirect("Admin_Home_Page.aspx");
        }
    }
}
