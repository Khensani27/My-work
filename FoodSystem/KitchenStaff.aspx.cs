using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class KitchenStaff : System.Web.UI.Page
    {
        private OrderController orderC = new OrderController();
        private Authentication auth = new Authentication();
        private FoodController foodController = new FoodController();
        protected async void Page_Load(object sender, EventArgs e)
        {
            string display = "";
            
            List<Order> orderList = await orderC.getOrder("Orders/getOrders");
            List<Order> ordersToRemove = new List<Order>();

            foreach (Order c in orderList)
            {
                if (c.OrderStatus.Equals("pending", StringComparison.OrdinalIgnoreCase) ||
                    (c.OrderStatus.Equals("processing", StringComparison.OrdinalIgnoreCase)) ||
                    (c.OrderStatus.Equals("Ready", StringComparison.OrdinalIgnoreCase) && c.OrderType.Equals("collection")))
                {


                    string OrderD = c.OrderDetails;
                    string[] ItemList = OrderD.Split(',');
                    string OrderDetails = "";
                    foreach (string word in ItemList)
                    {
                        string d = word;
                        if (!d.Equals(""))
                        {
                            int id = int.Parse(d);
                            Food foods = await foodController.getFood("Food/getFoodItem?ID=" + id);
                            OrderDetails += foods.Name + ",";
                        }
                    }


                    Users user = await auth.logIn("User/getUserByID?id=" + c.UserID);

                    if(user != null)
                    {
                        display += "<tr>";
                        display += "<th scope='row'> <a href='OrderDetails.aspx?Details=" + c.OrderDetails + "&orderID=" + c.Id + "' class='question_content'>" + user.U_ID + "</a></th>";
                        display += "<td>" + user.U_name + "</td>";//name
                        display += "<td><a href='OrderDetails.aspx?Details=" + c.OrderDetails + "&orderID=" + c.Id + "' class='status_btn'>" + OrderDetails + "</a></td>";//order details
                        display += "<td><a href='OrderDetails.aspx?Details=" + c.OrderDetails + "&orderID=" + c.Id + "' class='status_btn'>" + c.TotalCost + "</a></td>";//price
                        display += "<td>";
                        display += "<label for='cars'>" + c.OrderStatus + "</label>";
                        /*display += "<select name='update' id='update'>";
                        display += "<option value='processed'>Still pending</option>";
                        display += "<option value='processed'>Order being processed</option>";
                        display += "<option value='Ready'>Ready for pickup</option>";
                        display += "</select>";
                        display += "<a class='btn-book-a-table' style='background-color: #008000;color: black;' href='#'>Update Status</a>";*/
                        display += "</td>";
                        display += "</tr>";
                    }

                }

                // Check if the order status is "ready," "collected," or "delivered," and remove it from the list.
                else
                {
                    ordersToRemove.Add(c);
                }
            }
            table.InnerHtml = display;

            foreach (Order orderToRemove in ordersToRemove)
            {
                orderList.Remove(orderToRemove);
            }
        }
        protected void btnUpdate(object sender, EventArgs e)
        {
            /*string Name;
            decimal Price }
            int U_ID { get; set; }
            int F_ID }
            string Url { get; set; } = string.Empty;
            int Quantity { get; set; }
            string Category { get; set; } = string.Empty;*/
            /* Cart newCart = new Cart()
             {
                  Name;
                  Price;
                  U_ID;
                  F_ID;
                  Url;
                 Quantity;
                 Category;
             };*/
            //update
            /*string display = "";
            display += "<option value='processed'>Still pending</option>";
            display += "<option value='processed'>Order being processed</option>";
            display += "<option value='Ready>Ready for pickup</option>";*/

        }
    }
}