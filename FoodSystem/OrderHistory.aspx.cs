using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FinalYearWeb.Models;
using Newtonsoft.Json;

namespace FinalYearWeb
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["cart"] != null)
                {
                    // Retrieve the order details from the session
                    var orders = JsonConvert.DeserializeObject<List<Order>>(Session["cart"].ToString());

                    // Display the order details to the user
                    DisplayOrderDetails(orders);
                }
                else
                {
                    // Handle the case where there are no order details available in the session
                    // You can display a message or redirect the user as needed
                    orderhistory.InnerHtml = "No order details found.";
                }
            }
        }

        private void DisplayOrderDetails(List<Order> orders)
        {
            StringBuilder display = new StringBuilder();
            foreach (var order in orders)
            {
                display.Append("<div class='order-container'>");

                // Customize the order details display based on your order object structure
                display.AppendFormat("<div class='order-details col-sm-8 col-lg-4'>");
                display.AppendFormat("<h2 class='order-title'>{0}</h2>", order.OrderDetails);
                display.AppendFormat("<p class='order-status'>{0}</p>", order.OrderStatus);
                display.AppendFormat("<span class='order-cost'>{0:C2}</span>", order.TotalCost);
                // Add more order details as needed
                display.Append("</div>");

                display.Append("</div>");
            }

            // Set the HTML content to display the order details
            orderhistory.InnerHtml = display.ToString();
        }

        protected void ViewHistoryButton_Click(object sender, EventArgs e)
        {
            // Redirect to the OrderHistory.aspx page
            Response.Redirect("CustomerHome.aspx");
        }
    }
}
