using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Elibrary.Controllers;
using Elibrary.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Threading.Tasks;

namespace Elibrary
{
    public partial class Book_Store : System.Web.UI.Page
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
        protected async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            // Create the API URL with the search term
            string apiUrl = $"https://libraryapi-hxbwaxb4bdfkcvg9.southafricanorth-01.azurewebsites.net/api/Book/search?title={Uri.EscapeDataString(searchTerm)}&author={Uri.EscapeDataString(searchTerm)}&genre={Uri.EscapeDataString(searchTerm)}&isbn={Uri.EscapeDataString(searchTerm)}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send a GET request to the API
                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        var jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response to a List<Books>
                        var books = JsonSerializer.Deserialize<List<Books>>(jsonResponse, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true // Optional: allows case-insensitive property mapping
                        });

                        // Bind the result to the GridView
                        GridView1.DataSource = books;
                        GridView1.DataBind();
                    }
                    else
                    {
                        // Handle error or no results found
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        lblMessage.Text = "No books found matching the search criteria."; // Display message
                        lblMessage.CssClass = "text-warning"; // Optional: add a warning style
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    lblMessage.Text = "An error occurred while searching for books."; // Display message
                    lblMessage.CssClass = "text-danger"; // Optional: add a danger style
                }
            }
        }





        private async void BindAvailableBooks()
        {
           
            BookController auth = new BookController();

            
            List<Books> books = await auth.AllBooks("Book/getBooks");

            // Filter the list of books to show only those with 'Available' status
            var availableBooks = books.Where(book => book.Book_Status == "Available").ToList();

            // Bind the filtered list to the GridView
            GridView1.DataSource = availableBooks;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ReserveBook")
            {
                // Get the Book ID from CommandArgument
                int bookId = Convert.ToInt32(e.CommandArgument);
                string userId = (string)Session["User"];

                // Call the reserve method and pass the Book ID
                ReserveBook(bookId,userId);
            }
        }

        private async void ReserveBook(int bookId, string userId)
        {
            BookController books = new BookController();

            BorrowedBookController borrowedBooks = new BorrowedBookController();


            Books  b = await books.logIn("Book/getBook/"+bookId);
            //List<Borrowed_Books> borro = await borrowedBooks.getBorrowedBooks("Book/getAllBorrowedBooks");

            //api/Book/getAllBorrowedBooks



            if (b.Actual_Stock < 1)
            {
                b.Book_Status = "Unavailable";
                  
            }
            else
            {


                b.Actual_Stock = b.Actual_Stock - 1;
                b.Book_Status = "Available";

                Borrowed_Books borrowed = new Borrowed_Books()
                {

                    Book_Status = "Reserved",
                    Borrowed_Date = DateTime.Now,
                    Returned_Date = DateTime.Now.AddDays(3),
                    Book_ID = bookId,
                    User_ID = int.Parse(userId),
                    Fine = 0.00

                };

                HttpResponseMessage re = await borrowedBooks.AddBorrowed("Book/reserveBook", borrowed);
                if (re != null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('', 'success');", true);

                }
                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('', 'danger');", true);

                }


               
                 

            }
            HttpResponseMessage response = await books.updateBooks("Book/updateBook/"+bookId, b );

            if (response != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('Book reserved', 'success');", true);

            }
            else {

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('Book not reserved', 'danger');", true);

            }


          

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();

            //    // Check if the user has any outstanding fines
            //    string fineCheckQuery = "SELECT COUNT(*) FROM Borrowed_Books WHERE User_ID = @UserId AND Book_Status = 'Pending Fine'";
            //    using (SqlCommand fineCheckCmd = new SqlCommand(fineCheckQuery, con))
            //    {
            //        fineCheckCmd.Parameters.AddWithValue("@UserId", userId);
            //        int pendingFineCount = Convert.ToInt32(fineCheckCmd.ExecuteScalar());

            //        if (pendingFineCount > 0)
            //        {
            //            // If the user has a pending fine, show a popup message and return
            //            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('You have an outstanding fine, you cannot reserve a book.', 'danger');", true);
            //            return;
            //        }
            //    }

            //    // Check if the book has available stock
            //    string stockQuery = "SELECT Actual_Stock FROM Books WHERE Id = @BookId";
            //    using (SqlCommand stockCmd = new SqlCommand(stockQuery, con))
            //    {
            //        stockCmd.Parameters.AddWithValue("@BookId", bookId);
            //        int actualStock = Convert.ToInt32(stockCmd.ExecuteScalar());

            //        if (actualStock <= 0)
            //        {
            //            // If no stock is available, show a popup message
            //            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('This book is out of stock and cannot be reserved.', 'danger');", true);
            //            return;
            //        }
            //    }

            //    // Check if the user has already reserved a book
            //    string userCheckQuery = "SELECT COUNT(*) FROM Borrowed_Books WHERE User_ID = @UserId AND Book_Status = 'Reserved'";
            //    using (SqlCommand userCheckCmd = new SqlCommand(userCheckQuery, con))
            //    {
            //        userCheckCmd.Parameters.AddWithValue("@UserId", userId);
            //        int borrowedBooksCount = Convert.ToInt32(userCheckCmd.ExecuteScalar());

            //        if (borrowedBooksCount > 0)
            //        {
            //            // If the user has already reserved a book, show a popup message
            //            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('You have already reserved a book.', 'warning');", true);
            //            return;
            //        }
            //    }

            //    // Insert into Borrowed_Books table if validations pass
            //    string borrowBookQuery = "INSERT INTO Borrowed_Books(User_ID, Book_ID, Borrowed_Date, Returned_Date, Fine, Book_Status) " +
            //                             "VALUES(@user_ID, @Book_ID, @Borrowed_Date, @Returned_Date, @Fine, @Book_Status)";

            //    using (SqlCommand borrowCmd = new SqlCommand(borrowBookQuery, con))
            //    {
            //        borrowCmd.Parameters.AddWithValue("@user_ID", userId);
            //        borrowCmd.Parameters.AddWithValue("@Book_ID", bookId);
            //        borrowCmd.Parameters.AddWithValue("@Borrowed_Date", DateTime.Now); // Reserve date
            //        borrowCmd.Parameters.AddWithValue("@Returned_Date", DateTime.Now.AddDays(3)); // 3 days for a book to be reserved
            //        borrowCmd.Parameters.AddWithValue("@Fine", 0.00);
            //        borrowCmd.Parameters.AddWithValue("@Book_Status", "Reserved");

            //        borrowCmd.ExecuteNonQuery();
            //    }

            //    // Update the book's stock by decrementing it
            //    string updateQuery = "UPDATE Books SET Actual_Stock = Actual_Stock - 1 WHERE Id = @BookId";
            //    using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
            //    {
            //        updateCmd.Parameters.AddWithValue("@BookId", bookId);
            //        updateCmd.ExecuteNonQuery();
            //    }

            //    // Show a success message when the book is successfully reserved
            //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "showPopup('Book has been successfully reserved!', 'success');", true);
            //}
            BindAvailableBooks();
        }





    }
}