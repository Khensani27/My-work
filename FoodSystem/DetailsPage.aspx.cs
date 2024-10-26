using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class DetailsPage : System.Web.UI.Page
    {
        
        OrderController controller = new OrderController();
        private FoodController foodController = new FoodController();
        private RatingController ratingController = new RatingController();
        private Authentication userController = new Authentication();

        protected  void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    int orderId = Convert.ToInt32(Request.QueryString["ID"]);

                    DisplayOrderDetails(orderId);
                }
                else
                {
                    errorLabel.Text = "Order ID is missing.";
                }
            }
        }

        protected async void DisplayOrderDetails(int orderId)
        {
            Order order = await controller.getSingleOrder("Orders/getOrderById?ID=" + orderId);
            List<Food> foods = await foodController.listFood("Food/getAllFoods");
            List<Rating> ratings = await ratingController.getRating("Rating/getAllRatings");
            List<Users> users = await userController.GetUsers("User/getUsers");

            if (order != null)
            {
                Users user = users.FirstOrDefault(u => u.U_ID == order.UserID);

                if (user != null)
                {
                    // 1. Display customer details
                    userNameLabel.Text = user.U_name;
                    userEmailLabel.Text = user.U_Email;
                    userRegistrationDateLabel.Text = user.R_Date.ToString("yyyy-MM-dd");

                    // 2. Display order details
                    orderIdLabel.Text = order.Id.ToString();
                    orderStatusLabel.Text = order.OrderStatus;
                    orderDateLabel.Text = order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss");
                    if (order.OrderType == "collection")
                    {
                        orderCollectionTimeLabel.Text = order.CollectionTime.ToString();
                        deliveryOrCollectionLabel.Text = "Collection Time:";
                    }
                    else if (order.OrderType == "delivery")
                    {
                        orderCollectionTimeLabel.Text = order.CollectionTime.ToString();
                        deliveryOrCollectionLabel.Text = "Delivery Time:";
                        //deliveryPersonLabel.Text = order.DeliveryPersonName;
                    }
                    else
                    {
                        deliveryOrCollectionLabel.Text = "Unknown Order Type";
                    }
                    totalCostLabel.Text = order.TotalCost.ToString("C");

                    // 3. Display ordered items
                    List<string> orderDetailItems = order.OrderDetails.Split(',').ToList();

                    foreach (var item in orderDetailItems)
                    {
                        int itemId;
                        int quantity;
                        string[] itemParts = item.Split(':');

                        // Check if the item has the expected format with ID and quantity
                        if (itemParts.Length >= 2 && int.TryParse(itemParts[0], out itemId))// && int.TryParse(itemParts[1], out quantity))
                        {
                            // Find the food item by ID
                            Food orderedFood = foods.FirstOrDefault(food => food.Id == itemId);

                            if (orderedFood != null)
                            {
                                // Display item details separately
                                Label itemNameLabel = new Label();
                                itemNameLabel.Text = orderedFood.Name;
                                //itemPanel.Controls.Add(itemNameLabel);

                                Image itemImage = new Image();
                                itemImage.ImageUrl = orderedFood.Url;
                                itemImage.AlternateText = orderedFood.Name;
                                itemImage.Width = 100; // Set the desired width of the image
                               // itemPanel.Controls.Add(itemImage);

                              //  Label itemQuantityLabel = new Label();
                               // itemQuantityLabel.Text = "Quantity: " + quantity.ToString();
                               // itemPanel.Controls.Add(itemQuantityLabel);

                                Label itemPriceLabel = new Label();
                                itemPriceLabel.Text = "Price: " + orderedFood.Price.ToString("C");
                               // itemPanel.Controls.Add(itemPriceLabel);

                                // Add a line break between items
                             //   itemPanel.Controls.Add(new LiteralControl("<br /><br />"));
                            }
                        }
                    }

                    // 4. Display order rating (if order status is collected or delivered)
                    if (order.OrderStatus == "collected" || order.OrderStatus == "delivered")
                    {
                        Rating orderRating = ratings.FirstOrDefault(rating => rating.OrderId == order.Id);
                        if (orderRating != null)
                        {
                            orderRatingLabel.Text = "Order Rating: " + orderRating.OrderRating.ToString();
                        }
                        else
                        {
                            orderRatingLabel.Text = "Order Rating: Not Available";
                        }
                    }
                    else
                    {
                        orderRatingLabel.Text = "Order Rating: N/A";
                    }
                }

                else
                {
                    errorLabel.Text = "User not found for the given order.";
                }
                }
            else
            {
                errorLabel.Text = "Order not found.";
            }
        }


    }
}