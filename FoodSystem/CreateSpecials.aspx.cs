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
    public partial class CreateSpecials : System.Web.UI.Page
    {
        private int ItemID;
        MenuController menu = new MenuController();
        protected async void Page_Load(object sender, EventArgs e)
        {
            ItemID = int.Parse(Request.QueryString["ItemId"].ToString());
            Food foods = await menu.GetItem("Food/getFoodItem?ID=" + ItemID);
            Session["Item"] = foods;

            string display = "";
            display += "<section class='about_part'>";
            display += "<div class='container-fluid'>";
            display += "<div class='row align-items-center'>";
            display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
            display += "<div class='about_img'>";
            display += "<img src='" + foods.Url + "' alt='' height='400' width='250'/>";
            display += "</div>";
            display += "</div>";
            display += "<div class='col-sm-8 col-lg-4'>";
            display += "<div class='about_text'>";
            display += "<h5>" + foods.Name + "</h5>";
            display += "<p>" + foods.Description + "</p>";
            display += "<span>" + foods.Price + "</span>";
            display += "</div>";
            display += "</div>";
            display += "</div>";
            display += "</div>";
            display += "</section>";
            updateSpecial.InnerHtml = display;
        }
       

        protected async void btnCreateSpecials(object sender, EventArgs e)
        {

            Food newItem = Session["Item"] as Food;

            Food foodItem = new Food()
            {
                Id = newItem.Id,
                Name = newItem.Name,
                Description = newItem.Description,
                Price = decimal.Parse(priceSpecial.Text),
                Url = newItem.Url,
                Category = "special"
            };

            HttpResponseMessage responce = await menu.updateMenu("Food/updateMenu?ID=" + foodItem.Id +
            "&nameU=" + foodItem.Name + "&descriptionU=" + foodItem.Description + "&priceU=" + foodItem.Price + "&urlU=" +
            foodItem.Url + "&categoryU=" + foodItem.Category, foodItem);

            if (responce != null)
            {
                string display = "";
                display += "<section class='about_part'>";
                display += "<div class='container-fluid'>";
                display += "<div class='row align-items-center'>";
                display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
                display += "<div class='about_img'>";
                display += "<img src='"+ foodItem.Url + "' alt='' height='400' width='250'/>";
                display += "</div>";
                display += "</div>";
                display += "<div class='col-sm-8 col-lg-4'>";
                display += "<div class='about_text'>";
                display += "<h5>"+ foodItem.Name + "</h5>";
                display += "<p>"+ foodItem.Description + "</p>";
                display += "<span>R"+ foodItem.Price + "</span>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</section>";
                updateSpecial.InnerHtml = display;
            }
        }


    }
    
}