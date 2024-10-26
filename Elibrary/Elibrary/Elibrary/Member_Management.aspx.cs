using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Elibrary
{
    public partial class Member_Management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPendingUsers();
            }
        }

        private void BindPendingUsers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = "SELECT First_Name, Last_Name, Contact_No, Email, Address, Account_Status " +
                "FROM Users WHERE Account_Status = @AccountStatus";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AccountStatus", "Pending");

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
            string email = TextBox1.Text.Trim();

            if (!string.IsNullOrEmpty(email))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string query = "SELECT First_Name, Last_Name, Contact_No, Email, Address, Account_Status " +
                               "FROM Users WHERE Email = @Email";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TextBox2.Text = reader["First_Name"].ToString();
                                TextBox5.Text = reader["Last_Name"].ToString();
                                TextBox3.Text = reader["Contact_No"].ToString();
                                TextBox4.Text = reader["Email"].ToString();
                                TextBox6.Text = reader["Address"].ToString();
                                TextBox7.Text = reader["Account_Status"].ToString();
                            }
                            else
                            {
                                // Clear the text boxes if no user is found
                                ClearTextBoxes();
                            }
                        }
                    }
                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text.Trim();

            if (!string.IsNullOrEmpty(email))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                string query = "UPDATE Users SET Account_Status = @NewStatus WHERE Email = @Email"; // Update query to use Email

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@NewStatus", "Approved");
                        cmd.Parameters.AddWithValue("@Email", email); // Update parameter name to Email
                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                          
                            lblMessage.Text = "Account approved successfully.";
                            BindPendingUsers(); //Refresh
                            ClearTextBoxes(); 
                        }
                        else
                        {
                            // Failed to update
                            lblMessage.Text = "Error approving account.";
                        }
                    }
                }
            }
        }



        private void ClearTextBoxes()
        {
            TextBox2.Text = "";
            TextBox5.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
        }

    }
}
