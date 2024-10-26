using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Elibrary.Models;

namespace Elibrary
{
    public partial class Books_History : System.Web.UI.Page
    {
       
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    BindAvailableBooks();
                }

            }
        private void BindAvailableBooks()
        {
            string userId = (string)Session["User"];
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            // string query = "SELECT * FROM Books WHERE Book_Status = @BookStatus";
            string query = "SELECT DISTINCT  b.Title, b.ISBN, b.Genre,bb.Borrowed_Date,bb.Returned_Date, bb.Book_Status,CASE WHEN bb.Book_Status='Returned' OR bb.Book_Status='Reserved' OR DATEDIFF(DAY,Returned_Date,GETDATE())<0 THEN 0 ELSE DATEDIFF(DAY,Returned_Date,GETDATE())*30.50 END as 'Fine' FROM  Borrowed_Books bb INNER JOIN Books b ON b.Id=bb.Book_ID WHERE bb.User_ID=@User_ID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@user_ID", userId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
            }
        }
    }
}