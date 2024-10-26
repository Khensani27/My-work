using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Globalization;

namespace FinalYearWeb
{
    public partial class StoreSales : System.Web.UI.Page
    {
        private OrderController orderController = new OrderController();
        private FoodController foodController = new FoodController();
        private Authentication usersController = new Authentication();

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await GenerateWeeklyChartAsync();
                await GenerateMonthlyChartAsync();
                await GenerateYearlyChartAsync();
                await GenerateWeeklyPieChartAsync();
               // await DisplaySalesChart();
                //await GenerateDialyChartAsync();
            }
        }

        /****************************Sales Charts*************************************************/
        private async Task GenerateWeeklyChartAsync()
        {
            // Retrieve order data.
            List<Order> orders = await orderController.getOrder("Orders/getOrders");

            // Determine the start and end dates for the current week.
            DateTime currentDate = DateTime.Now.Date;
            DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // Filter orders for the current week.
            List<Order> ordersInCurrentWeek = orders.Where(order =>
                order.OrderDate.Date >= startOfWeek && order.OrderDate.Date <= endOfWeek).ToList();

            // Process the filtered data.
            Dictionary<DateTime, decimal> dailyTotalPrices = new Dictionary<DateTime, decimal>();

            foreach (var order in ordersInCurrentWeek)
            {
                DateTime orderDate = order.OrderDate.Date;

                if (dailyTotalPrices.ContainsKey(orderDate))
                {
                    dailyTotalPrices[orderDate] += order.TotalCost;
                }
                else
                {
                    dailyTotalPrices[orderDate] = order.TotalCost;
                }
            }
            // Convert the dailyTotalPrices dictionary to lists for JavaScript.
            List<decimal> data = dailyTotalPrices.Values.ToList();
            List<string> labels = dailyTotalPrices.Keys.Select(date => date.ToString("yyyy-MM-dd")).ToList();

            // Convert the lists to JSON for JavaScript consumption.
            string labelsJson = JsonConvert.SerializeObject(labels);
            string dataJson = JsonConvert.SerializeObject(data);

            // Render JavaScript code to build the chart.
            Page.ClientScript.RegisterStartupScript(GetType(), "BuildWeeklyChart", $@"
            var ctx = document.getElementById('weeklyChart').getContext('2d');
                var weeklyLineChart = new Chart(ctx, {{
                    type: 'line',
                    data: {{
                        labels: {labelsJson},
                        datasets: [
                        {{
                            
                            data: {dataJson},
                            label: 'Weekly Sales',
                            fill: false,
                            borderColor: '#6610f2'
                        }}
                    ]
                }},
                options: {{
                    // Customize chart options here
                }}
            }});
            ", true);
        }

        // Helper function to get the index of the day of the week.
        private int GetDayOfWeekIndex(string dayOfWeek)
        {
            // Define the order of days of the week for sorting.
            string[] daysOfWeekOrder = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            // Get the index of the day of the week in the defined order.
            int index = Array.IndexOf(daysOfWeekOrder, dayOfWeek);

            // If the dayOfWeek is not found in the defined order, return a large value to place it at the end.
            return index >= 0 ? index : daysOfWeekOrder.Length;
        }

        private async Task GenerateMonthlyChartAsync()
        {
            // Retrieve order data.
            List<Order> orders = await orderController.getOrder("Orders/getOrders");

            // Determine the start and end dates for the current month.
            DateTime currentDate = DateTime.Now.Date;
            DateTime startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            // Filter orders for the current month.
            List<Order> ordersInCurrentMonth = orders.Where(order =>
                order.OrderDate.Date >= startOfMonth && order.OrderDate.Date <= endOfMonth).ToList();

            // Process the filtered data.
            Dictionary<string, decimal> weeklyTotalPrices = new Dictionary<string, decimal>();

            foreach (var order in ordersInCurrentMonth)
            {
                // Calculate the week number for the order date.
                int weekNumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                    order.OrderDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                string weekYear = $"{startOfMonth.ToString("MMM yyyy")} - Week {weekNumber}";

                if (weeklyTotalPrices.ContainsKey(weekYear))
                {
                    weeklyTotalPrices[weekYear] += order.TotalCost;
                }
                else
                {
                    weeklyTotalPrices[weekYear] = order.TotalCost;
                }
            }


            var sortedData = weeklyTotalPrices.OrderBy(x => x.Key);

            // Convert the sorted data to lists for JavaScript.
            List<decimal> data = sortedData.Select(entry => entry.Value).ToList();
            List<string> labels = sortedData.Select(entry => entry.Key).ToList();


            // Convert the lists to JSON for JavaScript consumption.
            string labelsJson = JsonConvert.SerializeObject(labels);
            string dataJson = JsonConvert.SerializeObject(data);

            // Render JavaScript code to build the chart.
            Page.ClientScript.RegisterStartupScript(GetType(), "BuildMonthlyChart", $@"
                var ctx = document.getElementById('monthlyChart').getContext('2d');
                    var monthlyLineChart = new Chart(ctx, {{
                        type: 'line',
                        data: {{
                            labels: {labelsJson},
                            datasets: [
                            {{
                                label: 'Monthly Sales',
                                data: {dataJson},
                                fill: false,
                                borderColor: '#6610f2'
                            }}
                        ]
                    }},
                    options: {{
                        // Customize chart options here
                    }}
                }});
            ", true);
        }

        private async Task GenerateYearlyChartAsync()
        {
            // Retrieve order data.
            List<Order> orders = await orderController.getOrder("Orders/getOrders");

            // Determine the current year.
            int currentYear = DateTime.Now.Year;

            // Filter orders for the current year.
            List<Order> ordersInCurrentYear = orders.Where(order =>
                order.OrderDate.Year == currentYear).ToList();

           
            // Process the filtered data.
            Dictionary<string, decimal> monthlyTotalPrices = new Dictionary<string, decimal>();

            foreach (var order in ordersInCurrentYear)
            {
                string monthYear = order.OrderDate.ToString("MMM yyyy");

                if (monthlyTotalPrices.ContainsKey(monthYear))
                {
                    monthlyTotalPrices[monthYear] += order.TotalCost;
                }
                else
                {
                    monthlyTotalPrices[monthYear] = order.TotalCost;
                }
            }

            var sortedData = monthlyTotalPrices.OrderBy(x => DateTime.ParseExact(x.Key, "MMM yyyy", CultureInfo.InvariantCulture));


            // Convert the sorted data to lists for JavaScript.
            List<decimal> data = sortedData.Select(entry => entry.Value).ToList();
            List<string> labels = sortedData.Select(entry => entry.Key).ToList();

            // Convert the lists to JSON for JavaScript consumption.
            string labelsJson = JsonConvert.SerializeObject(labels);
            string dataJson = JsonConvert.SerializeObject(data);

            // Render JavaScript code to build the chart.
            Page.ClientScript.RegisterStartupScript(GetType(), "BuildYearlyChart", $@"
                var ctx = document.getElementById('yearlyChart').getContext('2d');
                    var yearlyLineChart = new Chart(ctx, {{
                        type: 'line',
                        data: {{
                            labels: {labelsJson},
                            datasets: [
                            {{
                                label: 'Yearly Sales',
                                data: {dataJson},
                                fill: false,
                                borderColor: '#6610f2'
                            }}
                        ]
                    }},
                    options: {{
                    // Customize chart options here
                    }}
                }});
            ", true);
        }

        /********************************Categories Chart********************************/

        private async Task GenerateWeeklyPieChartAsync()
        {
            // Retrieve food and order data.
            List<Food> foods = await foodController.listFood("Food/getAllFoods");
            List<Order> orders = await orderController.getOrder("Orders/getOrders");

            // Determine the start and end dates for the current week.
            DateTime currentDate = DateTime.Now.Date;
            DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // Filter orders for the current week.
            List<Order> ordersInCurrentWeek = orders
                .Where(order => order.OrderDate.Date >= startOfWeek && order.OrderDate.Date <= endOfWeek)
                .ToList();

            // Create a dictionary to store category-wise sales and quantities.
            Dictionary<string, Tuple<decimal, int>> categorySalesAndQuantities = new Dictionary<string, Tuple<decimal, int>>();


            // Iterate through filtered orders and update the dictionary.
            foreach (var order in ordersInCurrentWeek)
            {
                // Initialize a set to keep track of unique food items within each order.
                HashSet<string> uniqueFoodIds = new HashSet<string>();

                // Split the food IDs by commas.
                string[] foodIds = order.OrderDetails.Split(',');

                foreach (string foodIdStr in foodIds)
                {
                    if (int.TryParse(foodIdStr, out int foodId))
                    {
                        // Find the food item in the list of foods by its ID.
                        Food food = foods.FirstOrDefault(f => f.Id == foodId);

                        if (food != null)
                        {
                            string category = food.Category;

                            // Check if this food ID has already been processed within the same order.
                            if (!uniqueFoodIds.Contains(foodIdStr))
                            {
                                if (categorySalesAndQuantities.ContainsKey(category))
                                {
                                    var currentData = categorySalesAndQuantities[category];
                                    decimal currentSales = currentData.Item1 + order.TotalCost;
                                    int currentQuantity = currentData.Item2 + order.Quantity;
                                    categorySalesAndQuantities[category] = new Tuple<decimal, int>(currentSales, currentQuantity);
                                }
                                else
                                {
                                    categorySalesAndQuantities[category] = new Tuple<decimal, int>(order.TotalCost, order.Quantity);
                                }

                                // Add this food ID to the set to prevent duplicate processing.
                                uniqueFoodIds.Add(foodIdStr);
                            }
                        }
                    }
                }
            }

            // Convert the data to the format required for a pie chart.
            List<decimal> data = categorySalesAndQuantities.Values.Select(entry => entry.Item1).ToList();
            List<string> labels = categorySalesAndQuantities.Keys.ToList();

            // Convert the lists to JSON for JavaScript consumption.
            string labelsJson = JsonConvert.SerializeObject(labels);
            string dataJson = JsonConvert.SerializeObject(data);

            // Render JavaScript code to build the pie chart.
            Page.ClientScript.RegisterStartupScript(GetType(), "BuildWeeklyFoodCategoryPieChart", $@"
        var ctx = document.getElementById('weeklyPieChart').getContext('2d');
        var weeklyPieChart = new Chart(ctx, {{
            type: 'pie',
            data: {{
                labels: {labelsJson},
                datasets: [
                    {{
                        data: {dataJson},
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.7)',
                            'rgba(54, 162, 235, 0.7)',
                            'rgba(255, 206, 86, 0.7)',
                            'rgba(75, 192, 192, 0.7)',
                            'rgba(153, 102, 255, 0.7)',
                            'rgba(255, 159, 64, 0.7)',
                            'rgba(255, 99, 132, 0.7)'
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)',
                            'rgba(255, 99, 132, 1)'
                        ],
                    }}
                ]
            }},
            options: {{
                // Customize chart options here
            }}
        }});
    ", true);
        }


        /****************************************Daily Sales*********************************
        public async Task DisplaySalesChart()
        {
            try
            {
                // Make API calls to get orders and users data
                List<Order> orders = await orderController.getOrder("Orders/getOrders");
                List<Users> users = await usersController.GetUsers("User/getUsers");

                //var currentDate = DateTime.Now;
                //var firstDayOfWeek = currentDate.(DayOfWeek.Sunday); 
                DateTime currentDate = DateTime.Now.Date;
                DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);
                var lastDayOfWeek = startOfWeek.AddDays(6); 

                var weeklySalesData = new Dictionary<string, Dictionary<DateTime, decimal>>();

                // Filter orders for students and UJ staff for the current week
                var filteredOrders = orders
                    .Where(order => users.Any(user =>
                        (user.U_type == "Student" || user.U_type == "UJ Staff") &&
                        user.U_ID == order.UserID &&
                        order.OrderDate >= startOfWeek &&
                        order.OrderDate <= lastDayOfWeek))
                    .ToList();

                // Initialize weeklySalesData dictionary for each user
                foreach (var user in users)
                {
                    if (user.U_type == "Student" || user.U_type == "UJ Staff")
                    {
                        weeklySalesData[user.U_ID.ToString()] = new Dictionary<DateTime, decimal>();
                    }
                }

                // Fill the weeklySalesData dictionary with total sales for each day of the week
                for (var currentDateOfWeek = startOfWeek; currentDateOfWeek <= lastDayOfWeek; currentDateOfWeek = currentDateOfWeek.AddDays(1))
                {
                    decimal totalSalesForDay = filteredOrders
                        .Where(order => order.OrderDate.Date == currentDateOfWeek.Date)
                        .Sum(order => order.TotalCost);

                    foreach (var user in users)
                    {
                        if (user.U_type == "Student" || user.U_type == "UJ Staff")
                        {
                            string userId = user.U_ID.ToString();
                            weeklySalesData[userId][currentDateOfWeek] = totalSalesForDay;
                        }
                    }
                }

                // Call the function to display the weekly sales line charts
                DisplayWeeklySalesLineCharts(weeklySalesData);
            }
            catch (Exception ex)
            {
                // Handle exceptions (log them or display an error message)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void DisplayWeeklySalesLineCharts(Dictionary<string, Dictionary<DateTime, decimal>> weeklySalesData)
        {
            var datasets = new List<Dictionary<string, object>>();

            foreach (var userEntry in weeklySalesData)
            {
                string userId = userEntry.Key;
                var salesData = userEntry.Value.Values.ToList();

                var dataset = new Dictionary<string, object>
        {
            { "label", userId },
            { "data", salesData },
            { "backgroundColor", $"rgba({GetRandomColor()}, 0.2)" },
            { "borderColor", $"rgba({GetRandomColor()}, 1)" },
            { "borderWidth", 1 },
            { "fill", false }
        };

                datasets.Add(dataset);
            }

            var labels = weeklySalesData.First().Value.Keys.Select(date => date.ToString("yyyy-MM-dd")).ToList();

            var chartData = new Dictionary<string, object>
    {
        { "labels", labels },
        { "datasets", datasets }
    };

            // Convert data to JSON for JavaScript consumption
            string chartDataJson = JsonConvert.SerializeObject(chartData);

            // Render JavaScript code to build the line chart using Chart.js
            Page.ClientScript.RegisterStartupScript(GetType(), "BuildWeeklySalesLineCharts", $@"
        var ctx = document.getElementById('weeklyAreaChart').getContext('2d');
        var chartData = {chartDataJson};

        var config = {{
            type: 'line',
            data: chartData,
            options: {{
                scales: {{
                    x: {{
                        type: 'time',
                        time: {{
                            parser: 'date-fns',
                    unit: 'day',
                    displayFormats: {{
                        day: 'yyyy-MM-dd' // Use yyyy instead of YYYY
                    }},
                        }},
                        scaleLabel: {{
                            display: true,
                            labelString: 'Date'
                        }}
                    }},
                    y: {{
                        scaleLabel: {{
                            display: true,
                            labelString: 'Total Sales'
                        }}
                    }}
                }},
                plugins: {{
                    legend: {{
                        display: true,
                        position: 'top'
                    }},
                    title: {{
                        display: true,
                        text: 'Weekly Sales Line Chart'
                    }}
                }}
            }}
        }};

        var myChart = new Chart(ctx, config);
    ", true);
        }

        private string GetRandomColor()
        {
            Random random = new Random();
            return $"{random.Next(0, 256)}, {random.Next(0, 256)}, {random.Next(0, 256)}";
        }

        private async Task GenerateDialyChartAsync()
        {
            // Retrieve order data.
            List<Order> orders = await orderController.getOrder("Orders/getOrders");

            // Filter orders for the current day.
            DateTime currentDate = DateTime.Now.Date;
            DateTime startOfDay = currentDate;
            DateTime endOfDay = currentDate.AddDays(1).AddSeconds(-1);
            List<Order> ordersInCurrentDay = orders.Where(order =>
                order.OrderDate >= startOfDay && order.OrderDate <= endOfDay).ToList();

            // Create a list to store order data with timestamps and total prices.
            List<(DateTime Timestamp, decimal TotalPrice)> orderDataList = new List<(DateTime, decimal)>();

            // Populate the list with order data.
            foreach (var order in ordersInCurrentDay)
            {
                orderDataList.Add((order.OrderDate, order.TotalCost));
            }

            // Group the order data by 1-hour intervals.
            var groupedData = orderDataList.GroupBy(
                groupKey => new DateTime(groupKey.Timestamp.Year, groupKey.Timestamp.Month, groupKey.Timestamp.Day, groupKey.Timestamp.Hour, 0, 0),
                groupData => groupData.TotalPrice,
                (key, group) => new
                {
                    Timestamp = key,
                    TotalPrice = group.Sum()
                });

            // Extract labels and data for the chart.
            List<string> labels = groupedData.Select(data => data.Timestamp.ToString("yyyy-MM-dd HH:mm")).ToList();
            List<decimal> dataG = groupedData.Select(data => data.TotalPrice).ToList();

            // Convert the lists to JSON for JavaScript consumption.
            string labelsJson = JsonConvert.SerializeObject(labels);
            string dataJson = JsonConvert.SerializeObject(dataG);

            // Render JavaScript code to build the line chart using Chart.js.
            Page.ClientScript.RegisterStartupScript(GetType(), "BuildWeeklyChart", $@"
        var ctx = document.getElementById('hourlyChart').getContext('2d');
        var xArray = {labelsJson};
        var yArray = {dataJson};

        var myChart = new Chart(ctx, {{
            type: 'line',
            data: {{
                labels: xArray,
                datasets: [{{
                    label: 'Total Sales',
                    data: yArray,
                    backgroundColor: 'rgba(102, 16, 242, 0.2)',
                    borderColor: '#6610f2',
                    borderWidth: 2,
                    pointRadius: 5,
                    pointBackgroundColor: '#6610f2'
                }}]
            }},
            options: {{
                scales: {{
                    x: {{
                        type: 'time',
                        time: {{
                            unit: 'hour',
                            displayFormats: {{
                                hour: 'HH:mm'
                            }}
                        }},
                        scaleLabel: {{
                            display: true,
                            labelString: 'Time'
                        }}
                    }},
                    y: {{
                        scaleLabel: {{
                            display: true,
                            labelString: 'Total Sales'
                        }}
                    }}
                }},
                plugins: {{
                    legend: {{
                        display: true,
                        position: 'top'
                    }},
                    title: {{
                        display: true,
                        text: 'Orders Placed Every Two Hours'
                    }}
                }},
 adapter: {{
            date: {{
                  locale: enUS,
                  formats: {{
                    datetime: 'yyyy-MM-dd HH:mm', 
                }}
            }}

            }}
        }});
    ", true);
        } */

    }
}