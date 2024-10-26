using System;
using System.Net.Http;
using System.Web.UI.WebControls;
using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FinalYearWeb
{
    public partial class TrackOrder : System.Web.UI.Page
    {
        private Button viewOrderHistoryButton;
        private readonly HttpClient httpClient = new HttpClient();
        private readonly OrderController orderController = new OrderController();
        private int orderId;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await InitializePageAsync();
            }
        }

        private async Task InitializePageAsync()
        {
            await statusUpdateAsync();
        }

        private async Task statusUpdateAsync()
        {
            // Retrieve the user ID from the session.
            if (Session["UserIdToTrack"] != null)
            {
                int userIdToTrack = Convert.ToInt32(Session["UserIdToTrack"]);

                // Call the new endpoint to get the order by user ID.
                HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5280/api/Orders/getOrderByUserId?ID={userIdToTrack}");

                if (response.IsSuccessStatusCode)
                {
                    string orderJson = await response.Content.ReadAsStringAsync();
                    Order currentOrder = JsonConvert.DeserializeObject<Order>(orderJson);

                    if (currentOrder != null)
                    {
                        if (currentOrder.OrderStatus.Equals("pending"))
                        {
                            lblPending.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (currentOrder.OrderStatus.Equals("processing"))
                        {
                            lblPrepared.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (currentOrder.OrderStatus.Equals("Ready"))
                        {
                            lblReadyPickUp.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                else
                {
                    // Handle the case where the order for the specified user ID was not found.
                    // You can display an error message or take appropriate action.
                    // For now, let's assume the order was not found.
                    lblPending.Text = "Order Not Found";
                    lblPending.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                // Handle the case where the session variable for user ID is not set.
                // You can display an error message or take appropriate action.
                // For now, let's assume the user is not logged in.
                lblPending.Text = "User Not Logged In";
                lblPending.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrackOrder.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect($"RateOrder.aspx?orderId={orderId}");
            Response.Redirect("Rate.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderHistory.aspx");
        }
    }
}
