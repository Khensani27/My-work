using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FinalYearWeb
{
    public partial class DeleteIMenuItem : System.Web.UI.Page
    {
        private int ItemID;
        private MenuController menuController = new MenuController();
        protected async void Page_Load(object sender, EventArgs e)
        {
            ItemID = int.Parse(Request.QueryString["ItemId"].ToString());
            Food foods = await menuController.GetItem("Food/getFoodItem?ID=" + ItemID);
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
            update.InnerHtml = display;

        }
        
        private Food Item = null;
        

        private Food toBeDeleted = new Food();
        private int searchID = 0;
        private string searchName = "";

        protected async void btnDelete(object sender, EventArgs e)
        {
            Food itemDel = Session["Item"] as Food;

            bool results = await menuController.DeleteItem("Food/removeMenuItem?request="+itemDel.Id, itemDel);
            if(results == true)
            {
                string display = "";
                display += "<section class='about_part'>";
                display += "<div class='container-fluid'>";
                display += "<div class='row align-items-center'>";
                display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
                display += "<div class='about_img'>";
                display += "<img src='images/Deleted.JPG' alt='' height='400' width='250'/>";
                display += "</div>";
                display += "</div>";
                display += "<div class='col-sm-8 col-lg-4'>";
                display += "<div class='about_text'>";
                display += "<h5> Item Deleted </h5>";
                display += "<p> Item Deleted </p>";
                display += "<span> R 0 </span>";
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