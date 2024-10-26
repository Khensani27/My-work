using FinalYearWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class SingleItem : System.Web.UI.Page
    {
        private string name;
        private string url;
        private string price;
        private string description;
        private string Id;
        private string category;
        private string quantity;
        private int UserID;

        protected void Page_Load(object sender, EventArgs e)
        {

            name = Request.QueryString["name"].ToString();
            url = Request.QueryString["url"].ToString();
            price = Request.QueryString["price"].ToString();
            description = Request.QueryString["description"].ToString();
            Id = Request.QueryString["F_id"].ToString();
            category = Request.QueryString["category"].ToString();
            quantity = txtQuantity.Text;

            Session["Itemname"] = name;
            Session["ItemDescription"] = description;
            Session["ItemPrice"] = price;
            Session["ItemUrl"] = url;
            Session["ItemId"] = Id;
            Session["Itemcategory"] = category;
            Session["ItemQuantity"] = quantity;

            string display = "";

            display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
            display += "<div class='about_img'>";
            display += "<img src='"+url+"' alt='' width='500'/>";
            display += "</div>";
            display += "</div>";
            display += "<div class='col-sm-8 col-lg-4'>";
            display += "<div class='about_text'>";
            display += "<h5>"+name+"</h5>";
            display += "<p>"+description+"</p>";
            display += "<span>"+price+"</span>";
            display += "</div>";
            display += "</div>";

            singleItemID.InnerHtml = display;
        }
        protected void BtnAddToCart(object sender, EventArgs e)
        {
            string tocartName = Session["Itemname"] as string;
            string tocartDescription = Session["ItemDescription"] as string;
            string tocartPrice = Session["ItemPrice"] as string;
            string tocartUrl = Session["ItemUrl"] as string;
            string tocartId = Session["ItemId"] as string;
            string tocartCategory = Session["Itemcategory"] as string;
            string tocartQuantity = Session["ItemQuantity"] as string;
            Session["JustLogin"] = null;
            string sss = Session["U_ID"] as string;

            // Start handling the cart
            int userID = 0;
            string strID = Session["U_ID"] as string;
            if (strID != null)
            {
                userID = Convert.ToInt32(strID);
            }

            // Handling the shopping cart here
            if (Session["cart"] is string cartDataString)
            {
                var cart = JsonConvert.DeserializeObject<List<Order>>(cartDataString);
                // all implementation goes here
                var existingItem = cart.FirstOrDefault(item => item.ProductID == Convert.ToInt32(tocartId));

                if (existingItem != null)
                {
                    // Item already exists, increase its quantity and update total cost
                    existingItem.TotalCost += Convert.ToDecimal(price);
                    existingItem.Quantity += Convert.ToInt32(quantity);
                }
                else
                {
                    // Item does not exist, add it to the cart
                    var newItem = new Order
                    {
                        ProductID = Convert.ToInt32(tocartId),
                        TotalCost = Convert.ToDecimal(tocartPrice) * Convert.ToInt32(tocartQuantity),
                        Quantity = Convert.ToInt32(tocartQuantity),
                        OrderDetails = tocartDescription,
                        OrderDate = DateTime.Now,
                        OrderType = "",
                        OrderStatus = "ready_delivery",
                        CollectionTime = "",
                        UserID = userID
                    };
                    cart.Add(newItem);
                }

                var updatedCartDataString = JsonConvert.SerializeObject(cart);
                Session["cart"] = updatedCartDataString;
            }
            else
            {
                List<Order> cart = new List<Order>();
                // Handle all the logic here, all implementation
                // Item does not exist, add it to the cart
                var newItem = new Order
                {
                    ProductID = Convert.ToInt32(tocartId),
                    TotalCost = Convert.ToDecimal(tocartPrice) * Convert.ToInt32(tocartQuantity),
                    Quantity = Convert.ToInt32(tocartQuantity),
                    OrderDetails = tocartDescription,
                    OrderDate = DateTime.Now,
                    OrderType = "",
                    OrderStatus = "Kitchen_Ready",
                    CollectionTime = "",
                    UserID = userID
                };
                cart.Add(newItem);
                var updatedCartDataString = JsonConvert.SerializeObject(cart);
                Session["cart"] = updatedCartDataString;
            }





            if (sss == null)
            {
                Session["JustLogin"] = true;
                Response.Redirect("Login.aspx?name=" + tocartName + "&url=" + tocartUrl + "&price=" + tocartPrice + "&description=" + tocartDescription + "&F_id=" + tocartId + "&category="+ tocartCategory + "&quantity="+ tocartQuantity);
            }
            else
            {
                Response.Redirect("Cart.aspx");
            }



        }
    }
}