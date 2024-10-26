using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FinalYearWeb
{
    public partial class Cart : System.Web.UI.Page
    {
        /*private string name;
        private string url;
        private decimal price;
        private int quantity;
        private int U_ID;
        private string U_Type;
        private int F_ID;
        private string category;*/
        private FoodController foodController = new FoodController();
        
        
        protected async void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack) // Only calculate and store total amount if the page is not being reloaded due to a postback
            //{
            //    // Calculate total amount
            //    // decimal totalAmount = CalculateTotalAmount(); // Implement your calculation logic
                
            //    // Store total amount in Session
            Session["TotalAmount"] = null;
                
            //    // Rest of your existing code...
            //}

            if (Session["JustLogin"]==null)
            {
                string name = Session["Itemname"] as string;
                string description = Session["ItemDescription"] as string;
                string priceC = Session["ItemPrice"] as string;
                string image = Session["ItemUrl"] as string;
                string category = Session["Itemcategory"] as string;
                string foodIds = Session["ItemId"] as string;
                string userIds = Session["U_ID"] as string;
                string quantity = Session["ItemQuantity"] as string;

                int FoodId = int.Parse(foodIds);
                int UserId = int.Parse(userIds);
                int quantityId = int.Parse(quantity);
                
                FinalYearWeb.Models.Cart cart = await foodController.getcart("Food/getCart?U_ID=" + UserId + "&F_ID=" + FoodId);
                if (cart != null)
                {
                    cart.Quantity += quantityId;
                    await foodController.updateCart("Food/updateCart?ID="+ cart.Id + "&Itemname="+ cart.Name +"&priceU="+cart.Price+"&UserId="+cart.U_ID+"&ItemID="+ cart.F_ID+"&UrlU="+ cart.Url+"&quantity="+cart.Quantity+"&category="+cart.Category, cart);

                    Session["Itemname"] = null;
                    Session["ItemDescription"] = null;
                    Session["ItemPrice"] = null;
                    Session["ItemUrl"] = null;
                    Session["Itemcategory"] = null;
                    Session["ItemId"] = null;
                    Session["ItemQuantity"] = null;
                }
                else
                {
                    Models.Cart newCart = new Models.Cart
                    {
                        Quantity = quantityId,
                        F_ID = FoodId,
                        Price = decimal.Parse(priceC),
                        Category = category,
                        Url = image,
                        Name = name,
                        U_ID = UserId,
                    };
                    HttpResponseMessage responce = await foodController.addCart("Food/addToCart", newCart);
                    Session["Itemname"] = null;
                    Session["ItemDescription"] = null;
                    Session["ItemPrice"] = null;
                    Session["ItemUrl"] = null;
                    Session["Itemcategory"] = null;
                    Session["ItemId"] = null;   
                    Session["ItemQuantity"] = null;
                }

                List<Models.Cart> cartList = await foodController.getcarts("Food/getCarts?U_ID=" + UserId);

                // Calculate total amount
                decimal totalAmount = 0;
                if(cartList!=null && cartList.Count > 0)
                {
                    foreach (Models.Cart c in cartList)
                    {
                        totalAmount += c.Price * c.Quantity;
                    }
                }


                Session["TotalAmount"] = totalAmount.ToString();

                string display = "";
                foreach (Models.Cart c in cartList)
                {
                    display += "<th scope='row'>";
                    display += "<div class='d-flex align-items-center'>";
                    display += "<p class='mb-0'> </p>";
                    display += "<img src='" + c.Url + "' class='img-fluid rounded-3' style='width: 100px;' alt='Book'>";
                    display += "</div>";
                    display += "</th>";
                    display += "<td class='align-middle'>";
                    display += "<p class='mb-2'>" + c.Name + "</p>";
                    display += "</td>";
                    display += "<td class='align-middle'>";
                    display += "<div class='d-flex flex-row'>";
                    display += "<input id='form1' min='0' name='quantity' value='1' type='number' class='form-control form-control-sm' style='width: 50px;'/>";
                    display += "</div>";
                    display += "</td>";
                    display += "<td class='align-middle'>";
                    display += "<p class='mb-0' style='font-weight: 500;'>R" + c.Price + "</p>";
                    display += "</td>";
                    display += "<td>";
                    display += "<a class='btn-book-a-table' style='background-color: #f44336;color: black;' href=''>Remove</a>";
                    display += "</td>";
                }


                cart_rows.InnerHtml = display;



                string displayT = "";
                displayT += "<hr class='my-4'>";
                displayT += "<h3>Total <span>R" + totalAmount.ToString("0.00") + "</span></h3>";
                displayT += "<a class='btn-book-a-table' style='background-color: #008000;color: black;' href='CheckOut.aspx'>CheckOut</a>";
                total.InnerHtml = displayT;


            }
            else
            {
                string tocartName = Request.QueryString["name"].ToString();
                string tocartDescription = Request.QueryString["description"].ToString();
                string tocartPrice = Request.QueryString["price"].ToString();
                string tocartUrl = Request.QueryString["url"].ToString();
                string tocartId = Request.QueryString["F_id"].ToString();
                string tocartCategory = Request.QueryString["category"].ToString();
                string tocartQuantity = Request.QueryString["quantity"].ToString();


                int UserId = int.Parse(Request.QueryString["UserID"].ToString());
                int FoodId = int.Parse(tocartId);
                int quantity = int.Parse(tocartQuantity);

                FinalYearWeb.Models.Cart cart = await foodController.getcart("Food/getCart?U_ID=" + UserId + "&F_ID=" + FoodId);
                if (cart != null)
                {
                    cart.Quantity += quantity;
                    await foodController.updateCart("Food/updateCart?ID="+ cart.Id + "&Itemname="+ cart.Name +"&priceU="+cart.Price+"&UserId="+cart.U_ID+"&ItemID="+ cart.F_ID+"&UrlU="+ cart.Url+"&quantity="+cart.Quantity+"&category="+cart.Category, cart);

              
                }
                else
                {
                    Models.Cart newCart = new Models.Cart
                    {
                        Quantity = quantity,
                        F_ID = FoodId,
                        Price = decimal.Parse(tocartPrice),
                        Category = tocartCategory,
                        Url = tocartUrl,
                        Name = tocartName,
                        U_ID = UserId,
                    };
                    HttpResponseMessage responce = await foodController.addCart("Food/addToCart", newCart);

                }
                List<Models.Cart> cartList = await foodController.getcarts("Food/getCarts?U_ID=" + UserId);

                string display = "";
                foreach (Models.Cart c in cartList)
                {
                    display += "<tr>";
                    display += "<td>";
                    display += "<th scope='row'>";
                    display += "<div class='d-flex align-items-center'>";
                    display += "<p class='mb-0'> </p>";
                    display += "<img src='" + c.Url + "' class='img-fluid rounded-3' style='width: 100px;' alt='Book'>";
                    display += "</div>";
                    display += "</th>";
                    display += "<td class='align-middle'>";
                    display += "<p class='mb-2'>" + c.Name + "</p>";
                    display += "</td>";
                    display += "<td class='align-middle'>";
                    display += "<div class='d-flex flex-row'>";
                    display += "<input id='form1' min='0' name='quantity' value='1' type='number' class='form-control form-control-sm' style='width: 50px;'/>";
                    display += "</div>";
                    display += "</td>";
                    display += "<td class='align-middle'>";
                    display += "<p class='mb-0' style='font-weight: 500;'>R" + c.Price + "</p>";
                    display += "</td>";
                    display += "<td>";
                    display += "<a class='btn-book-a-table' style='background-color: #f44336;color: black;' href='#'>Remove</a>";
                    display += "</td>";
                    display += "</td>";
                    display += "</tr>";
                }
                cart_rows.InnerHtml = display;

                //string displayT = "";
                //displayT += "<hr class='my-4'>";
                //displayT += "<h3>Total <span>R" + totalAmount.ToString("0.00") + "</span></h3>";
                //displayT += "<a class='btn-book-a-table' style='background-color: #008000;color: black;' href='CheckOut.aspx'>CheckOut</a>";
                //total.InnerHtml = displayT;
            }

            




            /*name = Request.QueryString["name"].ToString();
            url = Request.QueryString["url"].ToString();
            price = Decimal.Parse(Request.QueryString["price"].ToString());
            quantity = Int32.Parse(Request.QueryString["quantity"].ToString());
            U_ID = Int32.Parse(Security.Security.decrypt(Request.QueryString["U_ID"].ToString()));
            F_ID = Int32.Parse(Security.Security.decrypt(Request.QueryString["F_ID"].ToString()));
            category = Security.Security.decrypt(Request.QueryString["category"].ToString());
            U_Type = Security.Security.decrypt(Request.QueryString["U_Type"].ToString());
            FinalYearWeb.Models.Cart cart = await foodController.getcart("Food/getCart?U_ID=" + U_ID + "&F_ID=" + F_ID);
            if(cart != null)
            {
                cart.Quantity += quantity;
                await foodController.updateCart("Food/updateCart",  cart);
            }
            else
            {
                Models.Cart newCart = new Models.Cart { 
                Quantity = quantity,
                F_ID= F_ID,
                Price = price,
                Category = category,
                Url = url,
                Name = name,
                U_ID= U_ID,
                };
                HttpResponseMessage responce = await foodController.addCart("Food/addToCart", newCart);
            }

            List<Models.Cart> cartList = await foodController.getcarts("Food/getCarts?U_ID=" + U_ID);
            decimal total = 0;
            string display = "";
            foreach(Models.Cart c in cartList)
            {
                display += "<ul class='cart_list'>";
                display += "<li class='cart_item clearfix'>";
                display += "<div class='cart_item_image'><img src='"+c.Url+"' alt=''></div>";
                display += "<div class='cart_item_info d-flex flex-md-row flex-column justify-content-between' >";
                display += "<div class='cart_item_name cart_info_col'>";
                display += "<div class='cart_item_title'>Name</div>";
                display += "<div class='cart_item_text'>"+c.Name+"</div></div>";
                display += "<div class='cart_item_quantity cart_info_col'>";
                display += "<div class='cart_item_title'>Quantity</div>";
                display += "<div class='cart_item_text'>"+c.Quantity+"</div></div>";
                display += "<div class='cart_item_price cart_info_col'>";
                display += "<div class='cart_item_title'>Price</div>";
                display += "<div class='cart_item_text'>"+c.Price+"</div></div>";
                display += "<div class='cart_item_total cart_info_col'>";
                display += "<div class='cart_item_title'>Total</div>";
                total += c.Quantity * c.Price;
                display += "<div class='cart_item_text'>"+(c.Quantity * c.Price)+"</div>";
                Response.Write("<asp:Button ID='Button1' runat='server' Text='Button'/>");
                display += "</div></div></li></ul>";
            }
            

            populateCart.InnerHtml = display;

            string display1 = "";
            display1 += "<div class='order_total_title'>Order Total:</div>";
            display1 += "<div class='order_total_amount'>R"+total+"</div>";
            totalAmount.InnerHtml = display1;*/


        }
        //private decimal CalculateTotalAmount()
        //{
        //    // Calculate the total amount logic
        //    decimal totalAmount = 0;
        //    // Perform the calculation here based on your cart data
        //    return totalAmount;
        //}

        protected void RedirectButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx");
        }
    }
}