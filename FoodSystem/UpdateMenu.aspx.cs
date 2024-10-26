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
    public partial class UpdateMenu : System.Web.UI.Page
    {
        FoodController foodController = new FoodController();
        protected async void Page_Load(object sender, EventArgs e)
        {
            List<Food> AllFoods = await foodController.listFood("Food/getAllFoods");
            string display = "";
            for (int i = 0; i < AllFoods.Count; i++)
            {
                display += "<div class='job-item p-4 mb-4'>";
                display += "<div class='row g-4'>";
                display += "<div class='col-sm-12 col-md-8 d-flex align-items-center'>";
                display += "<img class='flex-shrink-0 img-fluid border rounded' src='"+ AllFoods[i].Url + "' alt='' style='width: 200px; height: 200px;'/>";
                display += "<div class='text-start ps-4'>";
                display += "<h5 class='mb-3'>"+ AllFoods[i].Name + "</h5>";
                // display += "<span class='text-truncate me-3'>"+ AllFoods[i].Description + "</span>";
                display += "<p>" + AllFoods[i].Description + "</p>";
                display += "<span class='text-truncate me-3' style='font-size:20px;color:green'><i class='far fa-clock  me-2'></i>"+ AllFoods[i].Category + "</span>";
                display += "<span class='text-truncate me-0' style='font-size:20px;color:green'><i class='far fa-money-bill-alt me-2'></i>R"+ AllFoods[i].Price + "</span>";
                display += "</div>";
                display += "</div>";
                display += "<div class='col-sm-12 col-md-4 d-flex flex-column align-items-start align-items-md-end justify-content-center'>";
                display += "<div class='d-flex mb-3'>";
                display += "<a class='btn-book-a-table' style='background-color: #008000;color: black;width: 150px' href='UpdateMenuItem.aspx?ItemId=" + AllFoods[i].Id +"&ItemName="+ AllFoods[i].Name+ "'>Edit Item</a>";
                display += "</div>";
                display += "<div class='d-flex mb-3'>";
                display += "<a class='btn-book-a-table' style='background-color: #008000;color: black;width: 150px' href='CreateSpecials.aspx?ItemId=" + AllFoods[i].Id +"'>Put On Special</a>";
                display += "</div>";
                display += "<div class='d-flex mb-3'>";
                display += "<a class='btn-book-a-table' style='background-color: #FF0000;color: black;width: 150px' href='DeleteIMenuItem.aspx?ItemId=" + AllFoods[i].Id +"'>Delete Item</a>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
            }
            displayAll.InnerHtml = display;
        }
    }
}