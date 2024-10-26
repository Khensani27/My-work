using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elibrary
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAvailableBooks();
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            // Updated query to filter results where Book_Status is "Pending Fine" and search by First_Name, Last_Name, Title, etc.
            string query = @"
SELECT DISTINCT b.Id, u.First_Name AS UserFirstName, u.Last_Name AS UserSurname, 
                b.Title AS BookTitle, bb.Borrowed_Date, bb.Returned_Date, bb.Fine, bb.Book_Status
FROM Books b
INNER JOIN Borrowed_Books bb ON b.Id = bb.Book_ID
INNER JOIN Users u ON u.ID = bb.User_ID
WHERE bb.Book_Status = 'Pending Fine'
AND (b.Title LIKE '%' + @SearchTerm + '%'
OR b.Author LIKE '%' + @SearchTerm + '%'
OR b.Genre LIKE '%' + @SearchTerm + '%'
OR b.ISBN LIKE '%' + @SearchTerm + '%'
OR u.First_Name LIKE '%' + @SearchTerm + '%'
OR u.Last_Name LIKE '%' + @SearchTerm + '%')";

            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }



        private void BindAvailableBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = @"
        SELECT 
            bb.User_ID AS UserID,
            bb.Book_ID AS BookID,
            u.First_Name AS UserFirstName, 
            u.Last_Name AS UserSurname, 
            b.Title AS BookTitle, 
            bb.Borrowed_Date, 
            bb.Returned_Date, 
            bb.Fine, 
            bb.Book_Status 
        FROM 
            Borrowed_Books bb
        JOIN 
            Users u ON bb.User_ID = u.Id
        JOIN 
            Books b ON bb.Book_ID = b.Id
        WHERE 
            bb.Book_Status = 'Pending Fine'
        ORDER BY 
            u.First_Name";  // Add ORDER BY clause to sort by First_Name

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;  // Bind data to GridView1
                    GridView1.DataBind();
                }
            }
        }


        // Handle button click
        protected void btnSettleFine_Click(object sender, EventArgs e)
        {
            // Get the CommandArgument from the clicked button
            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split(',');
            string userId = args[0];
            int bookId = Convert.ToInt32(args[1]);

            // Call the method to settle the fine
            SettleFine(bookId, userId);
        }

        private void SettleFine(int bookId, string userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Update the Borrowed_Books table to set the fine and status
                string checkInQuery = "UPDATE Borrowed_Books SET " +
                                      "Fine=@fine, " +
                                      "Book_Status=@BookStatus " +
                                      "WHERE User_ID=@user_ID AND Book_ID=@Book_ID AND Book_Status='Pending Fine'";

                using (SqlCommand checkInCmd = new SqlCommand(checkInQuery, con))
                {
                    // Add the parameters
                    checkInCmd.Parameters.AddWithValue("@fine", 0); // Set the value of the fine, assuming 0 if cleared.
                    checkInCmd.Parameters.AddWithValue("@user_ID", userId);
                    checkInCmd.Parameters.AddWithValue("@Book_ID", bookId);
                    checkInCmd.Parameters.AddWithValue("@BookStatus", "Approved"); // Assuming you're setting the status to "Approved".

                    checkInCmd.ExecuteNonQuery();
                }

                // Rebind the GridView to reflect changes
                BindAvailableBooks();
            }
        }

    }
}
