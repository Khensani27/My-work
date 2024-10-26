using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elibrary
{
    public partial class Book_Issuing_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAvailableBooks();
            }

        }


        protected void btnReserve_Click(object sender, EventArgs e)
        {
            // Your search logic here
            string searchText = txtSearch.Text;
            // Example: Search for books based on the searchText
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            // Updated query to include Book_Status in the search criteria
            string query = @"SELECT DISTINCT b.Id, u.First_Name, u.Last_Name, b.Title, b.ISBN, b.Genre, bb.Book_Status
                     FROM Books b
                     INNER JOIN Borrowed_Books bb ON b.Id = bb.Book_ID
                     INNER JOIN Users u ON u.ID = bb.User_ID
                     WHERE (b.Title LIKE '%' + @SearchTerm + '%' 
                     OR b.Author LIKE '%' + @SearchTerm + '%' 
                     OR b.Genre LIKE '%' + @SearchTerm + '%' 
                     OR b.ISBN LIKE '%' + @SearchTerm + '%' 
                     OR u.First_Name LIKE '%' + @SearchTerm + '%' 
                     OR u.Last_Name LIKE '%' + @SearchTerm + '%' 
                     OR bb.Book_Status LIKE '%' + @SearchTerm + '%')"; // Added Book_Status search

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
            // string query = "SELECT * FROM Books WHERE Book_Status = @BookStatus";
            string query = "  SELECT DISTINCT u.Id as 'UserID',b.Id as 'BookID', u.First_Name,u.Last_Name,b.Title, b.ISBN, b.Genre, bb.Book_Status FROM [Users] u INNER JOIN Borrowed_Books bb ON u.ID=bb.User_ID INNER JOIN Books b ON b.Id=bb.Book_ID";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                 
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CheckOutBook" || e.CommandName == "CheckInBook")
            {
                // Split the CommandArgument to get both User_ID and Book_ID
                string[] args = e.CommandArgument.ToString().Split(',');

                String userId = Convert.ToInt32(args[0]).ToString(); // First part is User_ID
                int bookId = Convert.ToInt32(args[1]);  // Second part is Book_ID

                if (e.CommandName == "CheckOutBook")
                {
                    // Call the method to check out the book
                    CheckOutBook(bookId, userId);
                }
                else if (e.CommandName == "CheckInBook")
                {
                    // Call the method to check in the book
                    CheckInBook(bookId, userId);
                }
            }
        }


        protected void CheckOutBook(int bookId, string userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Update the Borrowed_Books table to set the status to 'Borrowed'
                string borrowBookQuery = "UPDATE Borrowed_Books SET " +
                                         "Book_Status=@Book_Status, Borrowed_Date=@Borrowed_Date, Returned_Date=@Returned_Date " +
                                         "WHERE User_ID=@user_ID AND Book_ID=@Book_ID AND Book_Status='Reserved'";

                using (SqlCommand borrowCmd = new SqlCommand(borrowBookQuery, con))
                {
                    borrowCmd.Parameters.AddWithValue("@user_ID", userId);
                    borrowCmd.Parameters.AddWithValue("@Book_ID", bookId);
                    borrowCmd.Parameters.AddWithValue("@Borrowed_Date", DateTime.Now); // Reserve date.
                    borrowCmd.Parameters.AddWithValue("@Returned_Date", DateTime.Now.AddDays(3));  // 3-day reservation period.
                    borrowCmd.Parameters.AddWithValue("@Book_Status", "Borrowed");

                    borrowCmd.ExecuteNonQuery();
                }

                // Show a success message with the updated text
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('The book has been borrowed.', 'success');", true);

                con.Close();
            }
            BindAvailableBooks();

        }

        protected void CheckInBook(int bookId, string userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            double fine = 0.00;
            double finePerDay = 30.50;   // Fine amount per day.
            string Status = "Returned";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Check if the book return is late, and calculate fine if applicable
                string fineQuery = "SELECT CASE WHEN Book_Status='Returned' OR Book_Status='Reserved' THEN 0 ELSE DATEDIFF(DAY,Returned_Date,GETDATE()) END  FROM Borrowed_Books WHERE Book_ID = @BookId AND User_ID=@User_ID";
                using (SqlCommand fineCmd = new SqlCommand(fineQuery, con))
                {
                    fineCmd.Parameters.AddWithValue("@BookId", bookId);
                    fineCmd.Parameters.AddWithValue("@User_ID", userId);

                    int lateDays = Convert.ToInt32(fineCmd.ExecuteScalar());

                    if (lateDays > 0) // If returned late
                    {
                        fine = lateDays * finePerDay; // Calculate fine
                        Status = "Pending Fine";
                    }
                }

                // Update the Borrowed_Books table to set the status to 'Returned'
                string checkInQuery = "UPDATE Borrowed_Books SET " +
                                      "Book_Status=@Book_Status " +
                                      ",Returned_Date=GETDATE() " +
                                      "WHERE User_ID=@user_ID AND Book_ID=@Book_ID AND Book_Status='Borrowed'";

                using (SqlCommand checkInCmd = new SqlCommand(checkInQuery, con))
                {
                    checkInCmd.Parameters.AddWithValue("@user_ID", userId);
                    checkInCmd.Parameters.AddWithValue("@Book_ID", bookId);
                    checkInCmd.Parameters.AddWithValue("@Book_Status", Status);

                    checkInCmd.ExecuteNonQuery();
                }

                // Update the Fine amount in the Borrowed_Books table if a fine is applicable
                if (fine > 0)
                {
                    string updateFineQuery = "UPDATE Borrowed_Books SET Fine=@Fine WHERE User_ID=@user_ID AND Book_ID=@Book_ID";

                    using (SqlCommand updateFineCmd = new SqlCommand(updateFineQuery, con))
                    {
                        updateFineCmd.Parameters.AddWithValue("@user_ID", userId);
                        updateFineCmd.Parameters.AddWithValue("@Book_ID", bookId);
                        updateFineCmd.Parameters.AddWithValue("@Fine", fine);

                        updateFineCmd.ExecuteNonQuery();
                    }
                }

                // Show a success message, including the fine if applicable
                string popupMessage = fine != 0
                    ? $"Book returned successfully. Your outstanding fine is R{fine}."
                    : "Book returned successfully.";

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", $"showPopup('{popupMessage}', 'success');", true);

                con.Close();
            }
            BindAvailableBooks();
        }

        private void ReserveBook(int bookId, string userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Check if the book has available stock
                string stockQuery = "SELECT Actual_Stock FROM Books WHERE Id = @BookId";
                using (SqlCommand stockCmd = new SqlCommand(stockQuery, con))
                {
                    stockCmd.Parameters.AddWithValue("@BookId", bookId);
                    int actualStock = Convert.ToInt32(stockCmd.ExecuteScalar());

                    if (actualStock <= 0)
                    {
                        // If no stock is available, show a popup message
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('This book is out of stock and cannot be reserved.', 'danger');", true);
                        return;
                    }
                }

                // Check if the user has already reserved a book.
                string userCheckQuery = "SELECT COUNT(*) FROM Borrowed_Books WHERE User_ID = @UserId AND Book_Status = 'Reserved'";
                using (SqlCommand userCheckCmd = new SqlCommand(userCheckQuery, con))
                {
                    userCheckCmd.Parameters.AddWithValue("@UserId", userId);
                    int borrowedBooksCount = Convert.ToInt32(userCheckCmd.ExecuteScalar());

                    if (borrowedBooksCount > 0)
                    {
                        // If the user has already reserved a book, show a popup message


                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('You have already reserved a book.', 'warning');", true);
                        return;

                    }
                }



                // Insert into Borrowed_Books table if validations pass
                string borrowBookQuery = "INSERT INTO Borrowed_Books(User_ID, Book_ID, Borrowed_Date, Returned_Date, Fine, Book_Status) " +
                                         "VALUES(@user_ID, @Book_ID, @Borrowed_Date, @Returned_Date, @Fine, @Book_Status)";

                using (SqlCommand borrowCmd = new SqlCommand(borrowBookQuery, con))
                {
                    borrowCmd.Parameters.AddWithValue("@user_ID", userId);
                    borrowCmd.Parameters.AddWithValue("@Book_ID", bookId);
                    borrowCmd.Parameters.AddWithValue("@Borrowed_Date", DateTime.Now);//Reserve date.
                    borrowCmd.Parameters.AddWithValue("@Returned_Date", DateTime.Now.AddDays(3));  //   3 days for a book to be reserved.
                    borrowCmd.Parameters.AddWithValue("@Fine", 0.00);
                    borrowCmd.Parameters.AddWithValue("@Book_Status", "Reserved");

                    borrowCmd.ExecuteNonQuery();
                }

                // Update the book's stock by decrementing it
                string updateQuery = "UPDATE Books SET Actual_Stock = Actual_Stock - 1 WHERE Id = @BookId";
                using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                {
                    updateCmd.Parameters.AddWithValue("@BookId", bookId);
                    updateCmd.ExecuteNonQuery();
                }

                // Show a success message when the book is successfully reserved
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('Book has been successfully reserved!', 'success');", true);

                con.Close();
            }
            BindAvailableBooks();
        }

    }
}