using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;
using System.Collections.Generic;
using System.Data;

namespace Elibrary
{
    public partial class Stats : Page
    {
        // Use the connection string from your Web.config file
        private string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load data for the charts and most borrowed book on the first page load
                LoadChartData();

                LoadMostBorrowedBooks(); // Load top 5 most borrowed books
                BindAvailableBooks();    // Load overdue books or books with pending fines
            }
        }

        // Method to load the data for the bar chart
        private void LoadChartData()
        {
            // Get the data for the bar chart (Books Borrowed Per Month)
            var borrowedBooksData = GetBorrowedBooksPerMonth();
            borrowedBooksBarChartData.Value = borrowedBooksData;
        }

        // Method to get the number of books borrowed each month
        private string GetBorrowedBooksPerMonth()
        {
            int[] borrowedBooksPerMonth = new int[12];  // For each month

            string query = @"
                SELECT MONTH(Borrowed_Date) AS Month, COUNT(*) AS BorrowCount
                FROM Borrowed_Books
                WHERE YEAR(Borrowed_Date) = YEAR(GETDATE())
                GROUP BY MONTH(Borrowed_Date)
                ORDER BY MONTH(Borrowed_Date)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int month = reader.GetInt32(0);  // Get the month (1 to 12)
                        int borrowCount = reader.GetInt32(1);  // Get the borrow count
                        borrowedBooksPerMonth[month - 1] = borrowCount;  // Store in array (index 0 = Jan)
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log or display errors)
                Console.WriteLine(ex.Message);
            }

            return "[" + string.Join(",", borrowedBooksPerMonth) + "]";
        }

        // Method to get the top 5 most borrowed books
        private DataTable GetMostBorrowedBooks()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT TOP 5 B.Title, COUNT(*) AS BorrowCount
                FROM Borrowed_Books BB
                JOIN Books B ON BB.Book_ID = B.Id
                GROUP BY B.Title
                ORDER BY BorrowCount DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);  // Fill the DataTable with the query result
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log or display errors)
                Console.WriteLine(ex.Message);
            }

            return dt;
        }

        // Method to bind the top 5 most borrowed books to the GridView
        private void LoadMostBorrowedBooks()
        {
            DataTable dt = GetMostBorrowedBooks();
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;  // Bind the data to GridView2
                GridView2.DataBind();
            }
            else
            {
                mostBorrowedBookLiteral.Text = "No data available.";
            }
        }

        // Method to bind books with pending fines to GridView1
        private void BindAvailableBooks()
        {
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
            u.First_Name";  // Sort by User's First Name

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

    }
}
