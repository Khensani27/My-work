using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        FoodController foodController = new FoodController();
        private OrderController orderC = new OrderController();
        protected async void Page_Load(object sender, EventArgs e)
        {
            string idO = Request.QueryString["orderID"];
            Session["OrderID"] = idO;
            string details = Request.QueryString["Details"];
            string[] ItemList = details.Split(',');


            string display = "";
            foreach (string word in ItemList)
            {
                string d = word;
                if (!string.IsNullOrEmpty(d))
                {
                    int id = int.Parse(d);
                    Food foods = await foodController.getFood("Food/getFoodItem?ID=" + id);


                    display += "<div class='job-item p-4 mb-4'>";
                    display += "<div class='row g-4'>";
                    display += "<div><h6>" + foods.Name + "</h6></div>";
                    display += "<div class='col-sm-12 col-md-8 d-flex align-items-center'>";
                    display += "<img class='flex-shrink-0 img-fluid border rounded' src='" + foods.Url + "' alt='' style='width: 200px; height: 200px;'/>";
                    display += "<div class='text-start ps-4'>";
                    display += "<p>" + foods.Description + "</p>";
                    display += "</div>";
                    display += "</div>";
                    display += "<div class='col-sm-12 col-md-4 d-flex flex-column align-items-start align-items-md-end justify-content-center'>";
                    display += "<span class='text-truncate me-0'><i class='far fa-money-bill-alt'></i>R" + foods.Price + "</span>";
                    display += "</div>";
                    display += "</div>";
                    display += "</div>";
                }
                else
                {
                    break;
                }

            }
            tab_1.InnerHtml = display;
        }
        protected async void btnUpdateStatus(object sender, EventArgs e)
        {
            string status = statusMenu.Value.ToString();

            string ID_Order = Session["OrderID"] as string;
            int id = int.Parse(ID_Order);
            Order orderList = await orderC.getSingleOrder("Orders/getOrderById?ID="+id);
            HttpResponseMessage responce = await orderC.updateOrderStatus("Orders/updateStatus?orderId=" + orderList.Id + "&status=" + status, orderList);
        }
    }
}