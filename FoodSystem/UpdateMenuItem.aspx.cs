using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class UpdateMenuItem : System.Web.UI.Page
    {
        private int ItemID;
        private string ItemName;
        protected async void Page_Load(object sender, EventArgs e)
        {

            ItemID = int.Parse(Request.QueryString["ItemId"].ToString());
            Food foods = await menu.GetItem("Food/getFoodItem?ID="+ItemID);
            Session["Item"] = foods;
            nameUpdate.Text = foods.Name;
            descriptionUpdate.Text = foods.Description;
            priceUpdate.Text = foods.Price.ToString();
            imageUpdate.Text = foods.Url;
            categoryList.SelectedValue = foods.Category;
            Session["Flag"] = "false";

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
            update.InnerHtml = display;

        }
        private string FilePath = "";
        
        protected void btnUpload(object sender, EventArgs e)
        {
            FileUpload1.SaveAs(Server.MapPath("~/images/" + FileUpload1.FileName));
            Status.Text = "File Uploaded";
            Status.ForeColor = System.Drawing.Color.Gray;
            FilePath = "images/" + FileUpload1.FileName;

            Session["ImagePath"] = FilePath;

            Session["Flag"] = "true";

        }


        MenuController menu = new MenuController();
        /*
        protected async void btnUpdateMenu(object sender, EventArgs e)
        {
            
            Food newItem = Session["Item"] as Food;
            Food foodItem;

            string fileP = Session["ImagePath"] as string;

            string ImageChange = Session["Flag"] as string;

            

            if (ImageChange.Equals("true"))
            {
                foodItem = new Food()
                {
                    Id = newItem.Id,
                    Name = nameUpdate.Text,
                    Description = descriptionUpdate.Text,
                    Price = decimal.Parse(priceUpdate.Text),
                    Url = fileP,
                    Category = categoryList.SelectedValue
                };
               
            }
            else
            {
                foodItem = new Food()
                {
                    Id = newItem.Id,
                    Name = nameUpdate.Text,
                    Description = descriptionUpdate.Text,
                    Price = decimal.Parse(priceUpdate.Text),
                    Url = newItem.Url,
                    Category = categoryList.SelectedValue
                };
            }

            HttpResponseMessage responce = await menu.updateMenu("Food/updateMenu?ID=" + foodItem.Id +
                "&nameU=" + foodItem.Name + "&descriptionU=" + foodItem.Description + "&priceU=" + foodItem.Price + "&urlU=" +
                foodItem.Url + "&categoryU=" + foodItem.Category, foodItem);

            if (responce != null && responce.IsSuccessStatusCode)
            {
                string display = "";
                display += "<section class='about_part'>";
                display += "<div class='container-fluid'>";
                display += "<div class='row align-items-center'>";
                display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
                display += "<div class='about_img'>";
                display += "<img src='" + foodItem.Url + "' alt='' height='400' width='250'/>";
                display += "</div>";
                display += "</div>";
                display += "<div class='col-sm-8 col-lg-4'>";
                display += "<div class='about_text'>";
                display += "<h5>" + foodItem.Name + "</h5>";
                display += "<p>" + foodItem.Description + "</p>";
                display += "<span>" + foodItem.Price + "</span>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</section>";
                update.InnerHtml = display;

                // Display a success message
                SuccessLabel.Text = "Update successful!";
                SuccessLabel.Visible = true;
            }
            else
            {
                // Display an error message
                SuccessLabel.Text = "Ooops! Couldn't update, sorry!";
                SuccessLabel.Visible = true;
            }

        } */

        protected async void btnUpdateMenu(object sender, EventArgs e)
        {

            Food newItem = Session["Item"] as Food;
            Food foodItem;

            string fileP = Session["ImagePath"] as string;
            string newName = nameUpdate.Text;
            string newDescription = descriptionUpdate.Text;
            decimal newPrice = decimal.Parse(priceUpdate.Text);
            string newCategory = categoryList.SelectedValue;

            string ImageChange = Session["Flag"] as string;

            if (ImageChange.Equals("true"))
            {
                foodItem = new Food()
                {
                    Id = newItem.Id,
                    Name = newName,
                    Description = newDescription,
                    Price = newPrice,
                    Url = fileP,
                    Category = newCategory
                };

            }
            else
            {
                foodItem = new Food()
                {
                    Id = newItem.Id,
                    Name = newName,
                    Description = newDescription,
                    Price = newPrice,
                    Url = newItem.Url,
                    Category = newCategory
                };
            }

            HttpResponseMessage responce = await menu.updateMenu("Food/updateMenu?ID=" + foodItem.Id +
                "&nameU=" + foodItem.Name + "&descriptionU=" + foodItem.Description + "&priceU=" + foodItem.Price + "&urlU=" +
                foodItem.Url + "&categoryU=" + foodItem.Category, foodItem);

            if (responce != null && responce.IsSuccessStatusCode)
            {
                string display = "";
                display += "<section class='about_part'>";
                display += "<div class='container-fluid'>";
                display += "<div class='row align-items-center'>";
                display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
                display += "<div class='about_img'>";
                display += "<img src='" + foodItem.Url + "' alt='' height='400' width='250'/>";
                display += "</div>";
                display += "</div>";
                display += "<div class='col-sm-8 col-lg-4'>";
                display += "<div class='about_text'>";
                display += "<h5>" + foodItem.Name + "</h5>";
                display += "<p>" + foodItem.Description + "</p>";
                display += "<span>" + foodItem.Price + "</span>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</section>";
                update.InnerHtml = display;

                // Display a success message
                SuccessLabel.Text = "Update successful!";
                SuccessLabel.Visible = true;
            }
            else
            {
                // Display an error message
                SuccessLabel.Text = "Ooops! Couldn't update, sorry!";
                SuccessLabel.Visible = true;
            }

        }
    }
}