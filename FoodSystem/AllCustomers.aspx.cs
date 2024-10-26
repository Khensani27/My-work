using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class AllCustomers : System.Web.UI.Page
    {
        private Authentication usersController = new Authentication();
        private OrderController orderController = new OrderController();
       // private TimePeriod selectedTimePeriod = TimePeriod.AllDates;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // selectedTimePeriod = TimePeriod.AllDates;
                DisplayUserDetailsTable();
               
            }
        }

        

        /************************************Customer Table******************************/

        protected async void DisplayUserDetailsTable()
        {
            // Fetch orders and users data from the API
            List<Order> orders = await orderController.getOrder("Orders/getOrders");
            List<Users> users = await usersController.GetUsers("User/getUsers");

            // Filter users who are students or UJ staff
            var allowedUserTypes = new List<string> { "Student", "UJ Staff" };
            var filteredUsers = users.Where(user => allowedUserTypes.Contains(user.U_type)).ToList();

            // Create a list to store user details
            List<UserDetails> userDetailsList = new List<UserDetails>();

            // Iterate through filtered users and gather required information
            foreach (var user in filteredUsers)
            {
                var userOrders = orders.Where(order => order.UserID == user.U_ID).ToList();
                var totalAmountSpent = userOrders.Sum(order => order.TotalCost);
                var numberOfOrders = userOrders.Count();
                var lastOrder = userOrders.OrderByDescending(order => order.OrderDate).FirstOrDefault();

                var userDetails = new UserDetails
                {
                    CustomerId = user.U_ID,
                    RegistrationDate = user.R_Date,
                    Name = user.U_name,
                    TotalAmountSpent = totalAmountSpent,
                    NumberOfOrders = numberOfOrders,
                    LastOrderTotalCost = lastOrder != null ? lastOrder.TotalCost : 0,
                    LastOrderDate = lastOrder != null ? lastOrder.OrderDate : (DateTime?)null  

                };

                userDetailsList.Add(userDetails);
            }
            userDetailsList = userDetailsList.OrderByDescending(user => user.RegistrationDate).ToList();


            //var userTable = new Table();

            var userTable = new Table
            {
                ID = "userTableLiteral", 
                ClientIDMode = ClientIDMode.Static 
            };


            // Create table headers
            var headerRow = new TableRow();
            headerRow.Cells.Add(new TableCell { Text = "Customer ID" });
            headerRow.Cells.Add(new TableCell { Text = "Registration Date" });
            headerRow.Cells.Add(new TableCell { Text = "Name" });
            headerRow.Cells.Add(new TableCell { Text = "Total Spent" });
            headerRow.Cells.Add(new TableCell { Text = "Total Orders" });
            headerRow.Cells.Add(new TableCell { Text = "Last Order Total" });
            headerRow.Cells.Add(new TableCell { Text = "Last Order Date" });

            userTable.Rows.Add(headerRow);

            // Apply styles or attributes to table headers
            foreach (TableCell cell in headerRow.Cells)
            {
                cell.CssClass = "header-cell"; // Add a CSS class to style the header cells
            }

            // Add user details rows to the table
            foreach (var userDetails in userDetailsList)
            {
                var row = new TableRow();
                row.Cells.Add(new TableCell { Text = userDetails.CustomerId.ToString() });
                row.Cells.Add(new TableCell { Text = userDetails.RegistrationDate.ToString() });
                row.Cells.Add(new TableCell { Text = userDetails.Name });
                row.Cells.Add(new TableCell { Text = userDetails.TotalAmountSpent.ToString("C") });
                row.Cells.Add(new TableCell { Text = userDetails.NumberOfOrders.ToString() });
                row.Cells.Add(new TableCell { Text = userDetails.LastOrderTotalCost.ToString("C") }); 
                row.Cells.Add(new TableCell { Text = userDetails.LastOrderDate.ToString() }); 


                foreach (TableCell cell in row.Cells)
                {
                    cell.CssClass = "data-cell"; // Add a CSS class to style the data cells
                }

                userTable.Rows.Add(row);
            }

            // Convert the table to an HTML string
            var htmlTable = new StringBuilder();
            using (var stringWriter = new StringWriter())
            {
                using (var htmlTextWriter = new HtmlTextWriter(stringWriter))
                {
                    userTable.RenderControl(htmlTextWriter);
                    htmlTable.Append(stringWriter.ToString());
                }
            }

            // Set the Literal control's Text property to the HTML table
            userTableLiteral.Text = htmlTable.ToString();
        }

        /***************************************Filter by date***************************
        protected void FilterButton_Click(object sender, EventArgs e)
        {
            string selectedTimePeriodValue = timePeriodDropDown.SelectedValue;

            // Parse the selected time period from the dropdown list
            if (Enum.TryParse(selectedTimePeriodValue, out TimePeriod timePeriod))
            {
                selectedTimePeriod = timePeriod;

                DisplayUserDetailsTable();
            }
            else
            {
                
            }
        }

        public enum TimePeriod
        {
            ThisWeek,
            ThisMonth,
            LastThreeMonths,
            AllDates
        }*/

        /******************User Details********************************/
        public class UserDetails
        {
            public int CustomerId { get; set; }
            public DateTime RegistrationDate { get; set; }
            public string Name { get; set; }
            public decimal TotalAmountSpent { get; set; }
            public int NumberOfOrders { get; set; }
            public decimal LastOrderTotalCost { get; set; }
            public DateTime? LastOrderDate { get; set; }
        }

    }
}