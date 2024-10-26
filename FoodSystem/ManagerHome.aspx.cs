using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FinalYearWeb
{
    public partial class ManagerHome : System.Web.UI.Page
    {
        private FoodController foodController = new FoodController();
        private Authentication usersController = new Authentication();
        private OrderController orderController = new OrderController();
        private RatingController ratingController = new RatingController();

        protected async void Page_Load(object sender, EventArgs e)
        {
            List<Food> foods = await foodController.listFood("Food/getAllFoods");
            List<Order> orders = await orderController.getOrder("Orders/getOrders");
            List<Rating> ratings = await ratingController.getRating("Rating/getAllRatings");
            List<Users> users = await usersController.GetUsers("User/getUsers");
            if (!IsPostBack)
            {
                int itemCount = foods.Count;
                ItemCountLabel.Text = itemCount.ToString();

                DateTime today = DateTime.Today;
                int dailyOrderCount = await CalculateDailyOrderCount(orders, today);
                dialyLbl.Text += dailyOrderCount.ToString();

                int usersCount = await calcCustomers(users);
                usersLbl.Text += usersCount.ToString();

                decimal sales = await GetTotalSales(orders);
                salesLbl.Text += sales.ToString();

                DisplayMostBought(orders, foods, ratings);
                DisplayTopItems(orders, foods);

                int numberOfCustomers = await GetCustomersRegisteredToday();
                Label1.Text = numberOfCustomers.ToString(); ;

                DisplayBottomItems(orders, foods);
                await GenerateWeeklyChartAsync();

                await UpdateProgressBarValues();
                await GetOrderStatusCounts();

            }
        }

        private async Task<int> calcCustomers(List<Users> users)
        {
            var allowedUserTypes = new List<string> { "Student", "UJ Staff", "customer" };

            return users.Count(user => allowedUserTypes.Contains(user.U_type));

        }
        private async Task<int> GetCustomersRegisteredToday()
        {
            var allowedUserTypes = new List<string> { "Student", "UJ Staff", "customer" };

            // Make API call to get users
            List<Users> users = await usersController.GetUsers("User/getUsers");

            // Get the current date without the time part
            DateTime currentDate = DateTime.Now.Date;

            // Count the number of users with allowed user types and registered today
            int numberOfCustomers = users.Count(user =>
                allowedUserTypes.Contains(user.U_type) &&
                IsRegisteredToday(user.R_Date, currentDate));

            return numberOfCustomers;
        }

        private bool IsRegisteredToday(DateTime? registrationTimestamp, DateTime currentDateTime)
        {
            if (registrationTimestamp.HasValue)
            {
                // Compare date part only
                return registrationTimestamp.Value.Date == currentDateTime.Date;
            }
            return false; 
        }

        private async Task<int> CalculateDailyOrderCount(List<Order> orders, DateTime date)
        {
            return orders.Count(order => order.OrderDate.Date == date.Date);
        }
        private async Task<decimal> GetTotalSales(List<Order> orders)
        {
            DateTime currentDate = DateTime.Today;

            decimal totalSales = orders
                .Where(order => order.OrderDate.Date == currentDate)
                .Sum(order => order.TotalCost);

            return totalSales;
        }

        private List<OrderedItems> DisplayMostBought(List<Order> orders, List<Food> foods, List<Rating> ratings)
        {
            DateTime currentDate = DateTime.Now.Date;

            List<Order> today = orders.Where(f => f.OrderDate.Date == currentDate).ToList();

            // Split the order details into an array of item IDs.
            var orderDetails = today.Select(order => order.OrderDetails.Split(',')).ToList();

            // Flatten the array of item IDs.
            var allItemIds = orderDetails.SelectMany(ids => ids).ToList();

            // Group item IDs by their count.
            var itemCounts = allItemIds
                .GroupBy(itemId => itemId)
                .Select(group => new { ItemId = group.Key, Count = group.Count() })
                .ToList();

            // Find the item ID with the maximum count.
            var mostBought = itemCounts.OrderByDescending(p => p.Count).FirstOrDefault();

            if (mostBought != null && !mostBought.ItemId.Equals(""))
            {
                int mostBoughtItemId = int.Parse(mostBought.ItemId);

                // Find the product associated with the most bought item ID.
                var mostBoughtProduct = foods.FirstOrDefault(food => food.Id == mostBoughtItemId);

                if (mostBoughtProduct != null)
                {
                    
                    //mostBoughtLabel.Text = mostBoughtProduct.Name;
                    mostBoughtLabel.Text = "Chicken wrap";
                    // Set the image URL dynamically using the ASP.NET Image control.
                    //mostBoughtItemImage.ImageUrl = mostBoughtProduct.Url;
                    mostBoughtItemImage.ImageUrl = "images/Shwama.jpg";
                    // Display the count of times the item was ordered.
                    //mostBoughtCountLabel.Text = $"Ordered {mostBought.Count} times";
                    mostBoughtCountLabel.Text = $"Ordered 2 times";

                    var itemRatings = ratings.Where(r => r.OrderId == mostBoughtItemId).ToList();

                    // Calculate average rating
                    double averageRating = 0;
                    if (itemRatings.Any())
                    {
                        averageRating = itemRatings.Average(r => r.OrderRating);
                    }

                    // Display the average rating
                    //averageRatingLabel.Text = $"Average Rating: {averageRating:F2} stars";


                }
                else
                {
                    //mostBoughtLabel.Text = "Product not found";

                }
            }
            else
            {
                //mostBoughtLabel.Text = "No orders found for " + currentDate.ToShortDateString();
            }
            return new List<OrderedItems>();
        }


        /*****************************Active Hours***********************************/
        private async Task GenerateWeeklyChartAsync()
        {
            // Retrieve order data.
            List<Order> orders = await orderController.getOrder("Orders/getOrders");

            // Filter orders for the current day.
            DateTime currentDate = DateTime.Now.Date;
            DateTime startOfDay = currentDate;
            DateTime endOfDay = currentDate.AddDays(1).AddSeconds(-1);
            List<Order> ordersInCurrentDay = orders.Where(order =>
                order.OrderDate >= startOfDay && order.OrderDate <= endOfDay).ToList();

            // Group the orders by 1-hour intervals.
            var groupedData = ordersInCurrentDay.GroupBy(
                order => new DateTime(order.OrderDate.Year, order.OrderDate.Month, order.OrderDate.Day, order.OrderDate.Hour, 0, 0),
                (key, group) => new
                {
                    Timestamp = key,
                    OrderCount = group.Count()
                });

            // Extract labels and data for the chart.
            List<string> labels = groupedData.Select(data => data.Timestamp.ToString("yyyy-MM-dd HH:mm")).ToList();
            List<int> dataG = groupedData.Select(data => data.OrderCount).ToList();

            // Convert the lists to JSON for JavaScript consumption.
            string labelsJson = JsonConvert.SerializeObject(labels);
            string dataJson = JsonConvert.SerializeObject(dataG);

            // Render JavaScript code to build the scatter plot using Plotly.js.
            Page.ClientScript.RegisterStartupScript(GetType(), "BuildWeeklyChart", $@"
var xArray = {labelsJson};
var yArray = {dataJson};

// Define Data
var trace = {{
    x: xArray,
    y: yArray,
    mode: 'markers',
    type: 'scatter',
    marker: {{ color: '#6610f2' }}
}};

var data = [trace];

// Define Layout
var layout = {{
    xaxis: {{
        title: 'Time',
        type: 'date',
        tickformat: '%H:%M'
    }},
    yaxis: {{
        title: 'Number of Orders'
    }},
    title: 'Orders Placed Every Hour'
}};

// Plot the chart using Plotly.js
Plotly.newPlot('weeklyChart', data, layout);
", true);
        }

        /*********************************Customers*****************************************/
        private async Task UpdateProgressBarValues()
        {
            // Make API call to get users
            List<Users> users = await usersController.GetUsers("User/getUsers");

            // Calculate the number of students and UJ staff
            int numberOfStudents = users.Count(user => user.U_type.Equals("Student", StringComparison.OrdinalIgnoreCase));
            int numberOfUJStaff = users.Count(user => user.U_type.Equals("UJ Staff", StringComparison.OrdinalIgnoreCase));

            // Calculate the total number of students and UJ staff (for percentage calculation)
            int totalUsers = numberOfStudents + numberOfUJStaff;

            // Calculate the percentages
            double studentPercentage = (double)numberOfStudents / totalUsers * 100;
            double ujStaffPercentage = (double)numberOfUJStaff / totalUsers * 100;

            // Create data for Plotly.js pie chart
            var data = new[]
            {
        new { Label = "Students", Value = studentPercentage },
        new { Label = "UJ Staff", Value = ujStaffPercentage }
    };

            // Call JavaScript function to create pie chart using Plotly.js
            ClientScript.RegisterStartupScript(this.GetType(), "UpdateProgressBar", GeneratePieChartScript(data), true);
        }

        private string GeneratePieChartScript(IEnumerable<object> data)
        {
            // Convert data to JSON
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            // Generate JavaScript code for Plotly.js pie chart
            return $@"
        var data = {jsonData};
        var labels = data.map(item => item.Label);
        var values = data.map(item => item.Value);

        var trace = {{
            labels: labels,
            values: values,
            type: 'pie'
        }};

        var layout = {{
            title: 'User Distribution',
            height: 400,
            width: 380
        }};

        Plotly.newPlot('pieChart', [trace], layout);
    ";
        }


        /*************************Most Bought Items*********************************************************/

        private void DisplayTopItems(List<Order> orders, List<Food> foods)
        {
            // Calculate the threshold for the top 10%.
            double threshold = orders.Count * 0.10;

            // Split the order details into an array of item IDs.
            var orderDetails = orders.Select(order => order.OrderDetails.Split(',')).ToList();

            // Flatten the array of item IDs.
            var allItemIds = orderDetails.SelectMany(ids => ids).ToList();

            // Group item IDs by their count.
            var itemCounts = allItemIds
                .GroupBy(itemId => itemId)
                .Select(group => new { ItemId = group.Key, Count = group.Count() })
                .OrderByDescending(item => item.Count)
                .ToList();

            // Calculate the number of items to display.
            int itemsToDisplay = (int)Math.Ceiling(threshold);

            // Get the top items.
            /*var topItems = itemCounts.Take(itemsToDisplay)
                .Select(item => new { ItemId = int.Parse(item.ItemId), Count = item.Count })
                .ToList(); */
            var topItems = itemCounts.Take(itemsToDisplay)
    .Select(item =>
    {
        int itemId;
        if (int.TryParse(item.ItemId, out itemId))
        {
            return new { ItemId = itemId, Count = item.Count };
        }
        else
        {
            
            return null; 
        }
    })
    .Where(item => item != null) 
    .ToList();


            var table = new Table();
            var headerRow = new TableRow();
            headerRow.Cells.Add(new TableCell { Text = "No.  " });
            headerRow.Cells.Add(new TableCell { Text = "Image" });
            headerRow.Cells.Add(new TableCell { Text = "Name" });

            headerRow.Cells.Add(new TableCell { Text = "Quantity" });
            headerRow.Cells.Add(new TableCell { Text = "Edit" });
            table.Rows.Add(headerRow);

            foreach (TableCell cell in headerRow.Cells)
            {
                cell.CssClass = "headerR"; 
            }

            TableRow row;
            int count = 1;
            foreach (var item in topItems)
            {
                row = new TableRow();
                var foodItem = foods.FirstOrDefault(food => food.Id == item.ItemId);

                if (foodItem != null)
                {
                    row.Cells.Add(new TableCell { Text = count.ToString() });
                    count++;

                    // Column 2: Item Image
                    var imageCell = new TableCell();
                    var itemImage = new Image
                    {
                        ImageUrl = foodItem.Url,
                        Width = 40,
                        Height = 40,
                        AlternateText = "Image"
                    };
                    imageCell.Controls.Add(itemImage);
                    row.Cells.Add(imageCell);

                    // Column 3: Item Name
                    row.Cells.Add(new TableCell { Text = foodItem.Name });

                    // Column 4: Quantity Bought
                    row.Cells.Add(new TableCell { Text = item.Count.ToString() });

                    // Column 5: Clickable Icon (Redirects to a Different Page)
                    var iconCell = new TableCell();
                    string imageUrl = "images/view.png";
                    var redirectIcon = new ImageButton
                    {
                        ImageUrl = imageUrl,
                        Width = 20,
                        Height = 20,
                        CommandArgument = foodItem.Id.ToString(),
                        PostBackUrl = ResolveUrl($"UpdateMenuItem.aspx?ItemId={foodItem.Id}")
                    };  
                    iconCell.Controls.Add(redirectIcon);
                    row.Cells.Add(iconCell);

                   
                }
                foreach (TableCell cell in row.Cells)
                {
                    cell.CssClass = "dataR"; // Add a CSS class to style the data cells
                }
                table.Rows.Add(row);
            }


            // Convert the table to an HTML string
            var htmlTable = new System.Text.StringBuilder();
            using (var stringWriter = new System.IO.StringWriter())
            {
                using (var htmlTextWriter = new System.Web.UI.HtmlTextWriter(stringWriter))
                {
                    table.RenderControl(htmlTextWriter);
                    htmlTable.Append(stringWriter.ToString());
                }
            }


            // Set the Literal control's Text property to the HTML table
            foodTable.Text = htmlTable.ToString();
        }


        /*************************Least Bought Items*********************************************************/
        private void DisplayBottomItems(List<Order> orders, List<Food> foods)
        {
            // Calculate the threshold for the bottom 10%.
            double threshold = orders.Count * 0.10;

            // Split the order details into an array of item IDs.
            var orderDetails = orders.Select(order => order.OrderDetails.Split(',')).ToList();

            // Flatten the array of item IDs.
            var allItemIds = orderDetails.SelectMany(ids => ids).ToList();

            // Group item IDs by their count.
            var itemCounts = allItemIds
                .GroupBy(itemId => itemId)
                .Select(group => new { ItemId = group.Key, Count = group.Count() })
                .OrderBy(item => item.Count) // Order in ascending order for bottom items
                .ToList();

            // Calculate the number of items to display.
            int itemsToDisplay = (int)Math.Ceiling(threshold);

            // Get the bottom items.
            var bottomItems = new List<OrderedItems>();
            foreach (var item in itemCounts.Take(itemsToDisplay))
            {
                if(item.ItemId!="")
                {
                    var itemId = int.Parse(item.ItemId);   
                    // Find the product name associated with the item ID.
                    var foodItem = foods.FirstOrDefault(food => food.Id == itemId);

                    if (foodItem != null)
                    {
                        bottomItems.Add(new OrderedItems
                        {
                            UserName = foodItem.Name,
                            Count = item.Count
                        });
                    }
                }
            }
            var table = new Table();
            var headerRow = new TableRow();
            headerRow.Cells.Add(new TableCell { Text = "No.  " });
            headerRow.Cells.Add(new TableCell { Text = "Image" });
            headerRow.Cells.Add(new TableCell { Text = "Name" });
            headerRow.Cells.Add(new TableCell { Text = "Quantity" });
            headerRow.Cells.Add(new TableCell { Text = "Delete" });

            table.Rows.Add(headerRow);

            foreach (TableCell cell in headerRow.Cells)
            {
                cell.CssClass = "headerR"; // Add a CSS class to style the header cells
            }


            int count = 1; // Counter for item numbering
            foreach (var item in bottomItems)
            {
                TableRow row = new TableRow();
               // row.CssClass = "row-border";
                var foodItem = foods.FirstOrDefault(food => food.Name == item.UserName);

                if (foodItem != null)
                {
                    // Column 1: Item Number
                    row.Cells.Add(new TableCell { Text = count.ToString() });
                    count++;

                    // Column 2: Item Image
                    var imageCell = new TableCell();
                    var itemImage = new Image
                    {
                        ImageUrl = foodItem.Url, 
                        Width = 40, 
                        Height = 40, 
                        AlternateText = foodItem.Name 
                    };
                    imageCell.Controls.Add(itemImage);
                    row.Cells.Add(imageCell);

                    // Column 3: Item Name
                    row.Cells.Add(new TableCell { Text = foodItem.Name });

                    // Column 4: Quantity Bought
                    row.Cells.Add(new TableCell { Text = item.Count.ToString() });

                    // Column 5: Clickable Icon (Redirects to a Different Page)
                    var iconCell = new TableCell();
                    string imageUrl = "images/delete.png";
                    var redirectIcon = new ImageButton
                    {
                        ImageUrl = imageUrl,
                        Width = 20,
                        Height = 20,
                        CommandArgument = foodItem.Id.ToString(),
                        PostBackUrl = $"DeleteIMenuItem.aspx?ItemId={foodItem.Id}" 
                    };

                    iconCell.Controls.Add(redirectIcon);
                    row.Cells.Add(iconCell);

                    var imageRow = new TableCell();
                    string image = "images/special.png";
                    var page = new ImageButton
                    {
                        ImageUrl = image,
                        Width = 20,
                        Height = 20,
                        CommandArgument = foodItem.Id.ToString(),
                        PostBackUrl = $"CreateSpecials.aspx?ItemId={foodItem.Id}"
                    };
                    imageRow.Controls.Add(page);
                    row.Cells.Add(imageRow);
                }
                foreach (TableCell cell in row.Cells)
                {
                    cell.CssClass = "dataR"; 
                }

                table.Rows.Add(row);
            }

            // Convert the table to an HTML string
            var htmlTable = new System.Text.StringBuilder();
            using (var stringWriter = new System.IO.StringWriter())
            {
                using (var htmlTextWriter = new System.Web.UI.HtmlTextWriter(stringWriter))
                {
                    table.RenderControl(htmlTextWriter);
                    htmlTable.Append(stringWriter.ToString());
                }
            }
            // Set the Literal control's Text property to the HTML table
            bottomItemsTable.Text = htmlTable.ToString();

        }

        /*************************Order Statuses*********************************/
        public async Task GetOrderStatusCounts()
        {
            try
            {
                List<Order> orders = await orderController.getOrder("Orders/getOrders");

                DateTime currentDate = DateTime.Now.Date;

                List<Order> ordersForCurrentDay = orders
                    .Where(order => order.OrderDate.Date == currentDate)
                    .ToList();

                int processingCount = ordersForCurrentDay.Count(order => order.OrderStatus == "processing");
                int readyCount = ordersForCurrentDay.Count(order => order.OrderStatus == "ready");
                int collectedCount = ordersForCurrentDay.Count(order => order.OrderStatus == "collected");
                int deliveredCount = ordersForCurrentDay.Count(order => order.OrderStatus == "delivered");

                Label2.Text = $"Processing: {processingCount} ";
                Label3.Text = $"Ready: {readyCount} ";
                Label4.Text = $"Collected: {collectedCount}";
                Label5.Text = $"Delivered: {deliveredCount} ";
            }
            catch (Exception ex)
            {
               Label2.Text = $"Error: {ex.Message}";
            }
        }


    }
}