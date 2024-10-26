using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Providers.Entities;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class StoreStats : System.Web.UI.Page
    {
        private FoodController foodController = new FoodController();
        private OrderController orderController = new OrderController();
        private RatingController ratingController = new RatingController();
        private Authentication userController = new Authentication();
        const int RowsPerPage = 10;
        int currentPage = 1;
        
        private List<OrderedItems> orderDetailsList;


        protected async void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                // Fetch orders data from the API
                List<Food> foods = await foodController.listFood("Food/getAllFoods");
                List<Order> orders = await orderController.getOrder("Orders/getOrders");
                List<Rating> ratings = await ratingController.getRating("Rating/getAllRatings");
                List<Users> user = await userController.GetUsers("User/getUsers");
               
                List<OrderedItems> orderDetailsList = await CreateOrderDetailsList(foods, orders,  user,"all");
 
                DisplayOrderDetailsTable(orderDetailsList);
                
            }
          
        }

        private async Task<List<OrderedItems>> CreateOrderDetailsList(List<Food> foods, List<Order> orders,  List<Users> users, string selectedStatus)
        {
            List<OrderedItems> orderDetailsList = new List<OrderedItems>();

            foreach (Order order in orders)
            {
                      List<string> foodItems = order.OrderDetails.Split(',')
    .Select(itemId =>
    {
        if (int.TryParse(itemId, out int parsedId))
        {
            var food = foods.FirstOrDefault(f => f.Id == parsedId);
            return food?.Name;
        }
        else
        {
            return "Invalid Item";
        }
    })
    .ToList();


                // Find the user associated with the order by matching user ID
                Users user = users.FirstOrDefault(u => u.U_ID == order.UserID);


                // Check if the order status matches the selected status, or if selected status is "All"
                if (selectedStatus == "all" || order.OrderStatus.Equals(selectedStatus, StringComparison.OrdinalIgnoreCase))
                {
                    // Create an OrderDetails object only if the status matches
                    OrderedItems orderDetails = new OrderedItems
                    {
                        OrderId = order.Id,
                        OrderDate = order.OrderDate,
                        FoodItems = foodItems,
                        UserName = user?.U_name,
                        OrderStatus = order.OrderStatus
                    };

                    orderDetailsList.Add(orderDetails);
                }


            }

            return orderDetailsList;
        }


        private void DisplayOrderDetailsTable(List<OrderedItems> orderDetailsList)
        {
            // Sort orderDetailsList by OrderDate in descending order
            orderDetailsList = orderDetailsList.OrderByDescending(order => order.OrderDate).ToList();

            // Calculate the starting and ending indices for the current page
            int startIndex = (currentPage - 1) * RowsPerPage;
            int endIndex = Math.Min(startIndex + RowsPerPage, orderDetailsList.Count);

            // Create an HTML table to display order details
            var orderTable = new Table();

            // Create table headers
            var headerRow = new TableRow();
            headerRow.Cells.Add(new TableCell { Text = "Order ID" });
            headerRow.Cells.Add(new TableCell { Text = "Order Date and Time" });
            headerRow.Cells.Add(new TableCell { Text = " Items Ordered" });
            headerRow.Cells.Add(new TableCell { Text = "Customer Name" });
            headerRow.Cells.Add(new TableCell { Text = "Order Status" });
            // headerRow.Cells.Add(new TableCell { Text = "Average Rating" });
            
            orderTable.Rows.Add(headerRow);

            // Apply styles or attributes to table headers
            foreach (TableCell cell in headerRow.Cells)
            {
                cell.CssClass = "header-cell"; // Add a CSS class to style the header cells
            }

            TableRow row;
            for (int i = startIndex; i < endIndex; i++)
            {
                var orderDetails = orderDetailsList[i];
                row = new TableRow();
                // Add order details rows
                  // Create a clickable Order ID that redirects to another page
                   
                     row.Cells.Add(new TableCell { Text = orderDetails.OrderId.ToString() });
                    row.Cells.Add(new TableCell { Text = orderDetails.OrderDate.ToString() });
                    row.Cells.Add(new TableCell { Text = string.Join(", ", orderDetails.FoodItems) });
                    row.Cells.Add(new TableCell { Text = orderDetails.UserName });
                     row.Cells.Add(new TableCell { Text = orderDetails.OrderStatus });

                    var orderIdCell = new TableCell();
                    var orderIdLink = new HyperLink
                    {
                    Text = "<i class='fas fa-info-circle'></i>",
                    NavigateUrl = $"DetailsPage.aspx?ID={orderDetails.OrderId}"
                    };
                orderIdCell.Controls.Add(orderIdLink);
                row.Cells.Add(orderIdCell);

                foreach (TableCell cell in row.Cells)
                    {
                        cell.CssClass = "data-cell"; // Add a CSS class to style the data cells
                    }
                    orderTable.Rows.Add(row);
                
            }

            // Convert the table to an HTML string
            var htmlTable = new System.Text.StringBuilder();
            using (var stringWriter = new System.IO.StringWriter())
            {
                using (var htmlTextWriter = new System.Web.UI.HtmlTextWriter(stringWriter))
                {
                    orderTable.RenderControl(htmlTextWriter);
                    htmlTable.Append(stringWriter.ToString());
                }
            }


            // Set the Literal control's Text property to the HTML table
            orderTableLiteral.Text = htmlTable.ToString();
        }

        /************************************Filtter with status****************************************/
        protected async void FilterButton_Click(object sender, EventArgs e)
        {
            string selectedStatus = orderStatusDropDown.SelectedValue;

            List<Food> foods = await foodController.listFood("Food/getAllFoods");
            List<Order> orders = await orderController.getOrder("Orders/getOrders");
            List<Users> users = await userController.GetUsers("User/getUsers");

            // Filter orders based on selected status
            List<OrderedItems> filteredOrders = await CreateOrderDetailsList(foods, orders,  users, selectedStatus);

            // Display filtered orders in the table
            DisplayOrderDetailsTable(filteredOrders);
        }

        private int displayedItemCount = 10;


        private void LoadOrders(int itemCount)
        {
            if (orderDetailsList != null)
            {
                DisplayOrderDetailsTable(orderDetailsList.Take(itemCount).ToList());
            }
        }

        protected void LoadMoreButton_Click(object sender, EventArgs e)
        {
            displayedItemCount += 10;
            LoadOrders(displayedItemCount);
        }


    }
}