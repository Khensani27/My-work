using Elibrary.Controllers;
using Elibrary.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elibrary
{
    public partial class Books_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindAvailableBooks();
        }


        private void BindAvailableBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = "SELECT Id, Author, Title, Edition, Publisher, Publication_Date, Genre, ISBN, Description, Book_Status, Actual_Stock FROM Books WHERE Book_Status = @BookStatus";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BookStatus", "Available");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string bookId = TextBox1.Text.Trim(); // Get BookID from input TextBox

            if (!string.IsNullOrEmpty(bookId))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string query = "SELECT Title, Author, Publisher, Publication_Date , Edition, Genre, ISBN, Description, Book_Status FROM Books WHERE Id = @BookID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BookID", bookId); // Bind the BookID parameter
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate text boxes with book details
                                txtTitle.Text = reader["Title"].ToString();
                                txtAuthor.Text = reader["Author"].ToString();
                                txtPublisher.Text = reader["Publisher"].ToString();
                                txtEdition.Text = reader["Edition"].ToString();
                                txtGenre.Text = reader["Genre"].ToString();
                                txtISBN.Text = reader["ISBN"].ToString();
                                txtDescription.Text = reader["Description"].ToString();
                                txtPublication_Date.Text= reader["Publication_Date"].ToString();
                                stock.Text = reader["Book_Status"].ToString();
                            }
                            else
                            {
                                // Clear text boxes if no book is found
                                ClearFields();
                                lblMessage.Text = "Book not found.";
                            }
                        }
                    }
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string bookId = TextBox1.Text.Trim(); // Get BookID from input TextBox

            if (!string.IsNullOrEmpty(bookId))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string query = "UPDATE Books SET Title = @Title, Author = @Author, Publisher = @Publisher, Edition = @Edition, Genre = @Genre, ISBN = @ISBN, Description = @Description, Actual_Stock=@Stock WHERE Id = @BookID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Bind parameters for updating book details
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                        cmd.Parameters.AddWithValue("@Publisher", txtPublisher.Text.Trim());
                        cmd.Parameters.AddWithValue("@Edition", txtEdition.Text.Trim());
                        cmd.Parameters.AddWithValue("@Genre", txtGenre.Text.Trim());
                        cmd.Parameters.AddWithValue("@ISBN", txtISBN.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@Publication_Date", txtPublication_Date.Text.Trim());
                        cmd.Parameters.AddWithValue("@Stock", stock.Text.Trim());
                        cmd.Parameters.AddWithValue("@BookID", bookId);

                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Successfully updated the book
                            lblMessage.Text = "Book details updated successfully.";
                            ClearFields(); // Optionally clear the text boxes
                        }
                        else
                        {
                            // Failed to update the book
                            lblMessage.Text = "Error updating book details.";
                        }
                    }
                }
            }
            BindAvailableBooks();
        }


        protected async void Register_Click(object sender, EventArgs e)
        {
            BookController auth = new BookController();

            Books book = new Books()
            {
                Author = txtAuthor.Text,
                Title = txtTitle.Text,
                Edition = txtEdition.Text,
                Publisher = txtPublisher.Text,
                Publication_Date = txtPublication_Date.Text,
                Genre = txtGenre.Text,
                ISBN = txtISBN.Text,
                Description = txtDescription.Text,
                Book_Status = "Available",
                Actual_Stock = int.Parse(stock.Text),
                // Book_Image = bookImage // Save the image path
    };

            HttpResponseMessage response = await auth.register("Book/addBook", book);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    lblMessage.Text = "Book Added successfully.";
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

            BindAvailableBooks();
        }


        protected void Delete_Click(object sender, EventArgs e)
        {
            string bookId = TextBox1.Text.Trim(); // Get BookID from input TextBox

            if (!string.IsNullOrEmpty(bookId))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string query = "DELETE FROM Books WHERE Id = @BookID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Bind the BookID parameter for deleting the book
                        cmd.Parameters.AddWithValue("@BookID", bookId);

                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Successfully deleted the book
                            lblMessage.Text = "Book deleted successfully.";
                            ClearFields(); // Optionally clear the text boxes
                        }
                        else
                        {
                            // Failed to delete the book
                            lblMessage.Text = "Error deleting the book. Please check the BookID.";
                        }
                    }
                }
            }
            else
            {
                lblMessage.Text = "Please enter a valid BookID.";
            }

            BindAvailableBooks();
        }


        private void ClearFields()
        {
            txtAuthor.Text = "";
            txtTitle.Text = "";
            txtEdition.Text = "";
            txtPublisher.Text = "";
            txtPublication_Date.Text = "";
            txtGenre.Text = "";
            txtISBN.Text = "";
            txtDescription.Text = "";
            //txtStatus.Text = "";
          
            //txtImage.Attributes.Clear(); // Clear the file upload control
        }
    }
}
