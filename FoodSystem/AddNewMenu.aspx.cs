using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class AddNewMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string display = "";
            display += "<section class='about_part'>";
            display += "<div class='container-fluid'>";
            display += "<div class='row align-items-center'>";
            display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
            display += "<div class='about_img'>";
            display += "<img src='images/image.png' alt='' height='400' width='250'/>";
            display += "</div>";
            display += "</div>";
            display += "<div class='col-sm-8 col-lg-4'>";
            display += "<div class='about_text'>";
            display += "<h5>Item Name</h5>";
            display += "<p>Your item descrption here </p>";
            display += "<span>Price</span>";
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

        }

        protected async void btnAddProduct(object sender, EventArgs e)
        {

            string fileP = Session["ImagePath"] as string;

            MenuController menu = new MenuController();
            Food food = new Food()
            {
                Name = nameID.Text,
                Description = despcriptionID.InnerText,
                Price = Convert.ToDecimal(priceID.Text),
                Url = fileP,
                Category = categoryID.Text,
            };
            HttpResponseMessage response = await menu.CreateNewItem("Food/addMenuItem", food);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string display = "";
                    display += "<section class='about_part'>";
                    display += "<div class='container-fluid'>";
                    display += "<div class='row align-items-center'>";
                    display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
                    display += "<div class='about_img'>";
                    display += "<img src='"+ food.Url + "' alt='' height='400' width='250'/>";
                    display += "</div>";
                    display += "</div>";
                    display += "<div class='col-sm-8 col-lg-4'>";
                    display += "<div class='about_text'>";
                    display += "<h5>"+ food.Name + "</h5>";
                    display += "<p>"+ food.Description + "</p>";
                    display += "<span>"+ food.Price + "</span>";
                    display += "</div>";
                    display += "</div>";
                    display += "</div>";
                    display += "</div>";
                    display += "</section>";

                    update.InnerHtml = display;
                }
            }
        }
    }
}