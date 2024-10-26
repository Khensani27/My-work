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
    public partial class CustomerHome : System.Web.UI.Page
    {
        FoodController foodController = new FoodController();
        private int U_ID;
        private string U_Type;
        protected async void Page_Load(object sender, EventArgs e)
        {
            List<Food> foods = await foodController.listFood("Food/getFoods?category=special");
            //U_ID = int.Parse(Request.QueryString["U_ID"].ToString());

            string display = "";
            for (int i = 0; i < foods.Count; i++)
            {
                display += "<div class='col-lg-4 menu-item'>";
                display += "<a href='SingleItem.aspx?name=" + foods[i].Name + "&url=" + foods[i].Url + "&price=" + foods[i].Price + "&description=" + foods[i].Description + "&F_id=" + foods[i].Id + "&category=" + foods[i].Category + "' class='glightbox'><img src='" + foods[i].Url + "' class='menu-img img-fluid' alt=''></a>";
                display += "<h4>" + foods[i].Name + "</h4>";
                display += "<p class='ingredients'>" + foods[i].Description + "</p>";
                display += "<p class='price'>R " + foods[i].Price + "</p>";
                display += "</div>";

            }
            specials.InnerHtml = display;


            List<Food> foodsB = await foodController.listFood("Food/getFoods?category=breakfast");
            string displayB = "";
            for (int i = 0; i < foodsB.Count; i++)
            {
                displayB += "<div class='col-lg-4 menu-item'>";
                displayB += "<a href='SingleItem.aspx?name=" + foodsB[i].Name + "&url=" + foodsB[i].Url + "&price=" + foodsB[i].Price + "&description=" + foodsB[i].Description + "&F_id=" + foodsB[i].Id + "&category=" + foodsB[i].Category + "' class='glightbox'><img src='" + foodsB[i].Url + "' class='menu-img img-fluid' alt=''></a>";
                displayB += "<h4>" + foodsB[i].Name + "</h4>";
                displayB += "<p class='ingredients'>" + foodsB[i].Description + "</p>";
                displayB += "<p class='price'>R " + foodsB[i].Price + "</p>";
                displayB += "</div>";

            }
            breakfast.InnerHtml = displayB;

            List<Food> foodsL = await foodController.listFood("Food/getFoods?category=lunch");
            string displayL = "";
            for (int i = 0; i < foodsL.Count; i++)
            {
                displayL += "<div class='col-lg-4 menu-item'>";
                displayL += "<a href='SingleItem.aspx?name=" + foodsL[i].Name + "&url=" + foodsL[i].Url + "&price=" + foodsL[i].Price + "&description=" + foodsL[i].Description + "&F_id=" + foodsL[i].Id + "&category=" + foodsL[i].Category + "' class='glightbox'><img src='" + foodsL[i].Url + "' class='menu-img img-fluid' alt=''></a>";
                displayL += "<h4>" + foodsL[i].Name + "</h4>";
                displayL += "<p class='ingredients'>" + foodsL[i].Description + "</p>";
                displayL += "<p class='price'>R " + foodsL[i].Price + "</p>";
                displayL += "</div>";

            }
            lunch.InnerHtml = displayL;


            List<Food> foodsD = await foodController.listFood("Food/getFoods?category=dessert");
            string displayD = "";
            for (int i = 0; i < foodsD.Count; i++)
            {
                displayD += "<div class='col-lg-4 menu-item'>";
                displayD += "<a href='SingleItem.aspx?name=" + foodsD[i].Name + "&url=" + foodsD[i].Url + "&price=" + foodsD[i].Price + "&description=" + foodsD[i].Description + "&F_id=" + foodsD[i].Id + "&category=" + foodsD[i].Category + "' class='glightbox'><img src='" + foodsD[i].Url + "' class='menu-img img-fluid' alt=''></a>";
                displayD += "<h4>" + foodsD[i].Name + "</h4>";
                displayD += "<p class='ingredients'>" + foodsD[i].Description + "</p>";
                displayD += "<p class='price'>R " + foodsD[i].Price + "</p>";
                displayD += "</div>";

            }
            dinner.InnerHtml = displayD;

            List<Food> foodsDr = await foodController.listFood("Food/getFoods?category=drinks");
            string displayDr = "";
            for (int i = 0; i < foodsDr.Count; i++)
            {
                displayDr += "<div class='col-lg-4 menu-item'>";
                displayDr += "<a href='SingleItem.aspx?name=" + foodsDr[i].Name + "&url=" + foodsDr[i].Url + "&price=" + foodsDr[i].Price + "&description=" + foodsDr[i].Description + "&F_id=" + foodsDr[i].Id + "&category=" + foodsDr[i].Category + "' class='glightbox'><img src='" + foodsDr[i].Url + "' class='menu-img img-fluid' alt=''></a>";
                displayDr += "<h4>" + foodsDr[i].Name + "</h4>";
                displayDr += "<p class='ingredients'>" + foodsDr[i].Description + "</p>";
                displayDr += "<p class='price'>R " + foodsDr[i].Price + "</p>";
                displayDr += "</div>";

            }
            drinks.InnerHtml = displayDr;


            //    // Get the user's ID (You should replace this with your actual logic to get the user's ID)
            //    int userId = GetLoggedInUserId();

            //    // Check if the user is logged in
            //    if (userId > 0)
            //    {
            //        // Get the user's favorite items
            //        List<Food> favoriteFoods = await foodController.GetFavoriteFoods(userId);

            //        string favoritesDisplay = "";
            //        foreach (var favorite in favoriteFoods)
            //        {
            //            favoritesDisplay += "<div class='col-lg-4 menu-item'>";
            //            favoritesDisplay += "<a href='SingleItem.aspx?name=" + favorite.Name + "&url=" + favorite.Url + "&price=" + favorite.Price + "&description=" + favorite.Description + "&F_id=" + favorite.Id + "&category=" + favorite.Category + "' class='glightbox'><img src='" + favorite.Url + "' class='menu-img img-fluid' alt=''></a>";
            //            favoritesDisplay += "<h4>" + favorite.Name + "</h4>";
            //            favoritesDisplay += "<p class='ingredients'>" + favorite.Description + "</p>";
            //            favoritesDisplay += "<p class='price'>R " + favorite.Price + "</p>";
            //            favoritesDisplay += "<button class='remove-favorite' data-food-id='" + favorite.Id + "'>Remove from Favorites</button>";
            //            favoritesDisplay += "</div>";
            //        }
            //        favorites.InnerHtml = favoritesDisplay;

            //        // Add script to handle add and remove button clicks
            string script = @"
                    <script>
                    $(document).ready(function () {
                        $('.add-favorite').click(function() {
                            var foodId = $(this).data('food-id');
                            addFavorite(foodId);
                        });

                        $('.remove-favorite').click(function() {
                            var foodId = $(this).data('food-id');
                            removeFavorite(foodId);
                        });
                    });
                    script>";

            //        // Register the script to the page
            //        ClientScript.RegisterStartupScript(this.GetType(), "FavoritesScript", script, false);
            //    }
            //}

            // Rest of the code for listing different food categories...

            // Rest of the code for listing different food categories...

            // Get the logged-in user's ID (Replace this with your own logic)
            //private int GetLoggedInUserId()
            //{
            //    // Your logic to get the user's ID here
            //    // Return the user's ID or 0 if not logged in
            //}
            /*U_ID = Int32.Parse(Security.Security.decrypt(Request.QueryString["U_ID"].ToString()));
            U_Type = Security.Security.decrypt(Request.QueryString["U_Type"].ToString());
            List<Food> foods = await foodController.listFood("Food/getFoods?category=breakfast");
            string display = "";
            for (int i = 0; i < foods.Count; i++)
            {

                if(i < 2)
                {
                    display += "<div class='col-6 col-lg-6 mb-4'>";
                    display += "<div class='product'>";
                    display += "<a href='Galary.aspx?name=" + foods[i].Name + "&url=" + foods[i].Url + "&price=" + foods[i].Price + "&U_ID="+Security.Security.encrypt(""+U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ foods[i].Id + "&category="+ Security.Security.encrypt(foods[i].Category) + "' class='thumbnail'><img src='" + foods[i].Url + "' alt='Image' class='img-fluid'></a>";
                    display += "<h3><a href='Galary.aspx?name=" + foods[i].Name + "&url=" + foods[i].Url + "&price=" + foods[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ foods[i].Id + "&category="+ Security.Security.encrypt(foods[i].Category) + "'>" + foods[i].Name + "</a></h3>";
                    display += "<div class='d-flex'>";
                    display += "<div class='price'>R" + foods[i].Price + "</div>";
                    display += "</div></div></div>";
                }
                else
                {
                    display += "<div class='col-6 col-lg-6 mb-0'>";
                    display += "<div class='product'>";
                    display += "<a href='Galary.aspx?name=" + foods[i].Name + "&url=" + foods[i].Url + "&price=" + foods[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ foods[i].Id + "&category="+ Security.Security.encrypt(foods[i].Category) + "' class='thumbnail'><img src='" + foods[i].Url + "' alt='Image' class='img-fluid'></a>";
                    display += "<h3><a href='Galary.aspx?name=" + foods[i].Name + "&url=" + foods[i].Url + "&price=" + foods[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ foods[i].Id + "&category="+ Security.Security.encrypt(foods[i].Category) + "'>" + foods[i].Name + "</a>" + foods[i].Name + "</h3>";
                    display += "<div class='d-flex'>";
                    display += "<div class='price'>R" + foods[i].Price + "</div>";
                    display += "</div></div></div>";
                }
            }
            breakfast.InnerHtml = display;
            string display2 = "";

            List<Food> lunchFood = await foodController.listFood("Food/getFoods?category=lunch");
            for (int i = 0; i < lunchFood.Count; i++)
            {

                if (i < 2)
                {
                    display2 += "<div class='col-6 col-lg-6 mb-4'>";
                    display2 += "<div class='product'>";
                    display2 += "<a href='Galary.aspx?name=" + lunchFood[i].Name + "&url=" + lunchFood[i].Url + "&price=" + lunchFood[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ lunchFood[i].Id + "&category="+ Security.Security.encrypt(lunchFood[i].Category) + "' class='thumbnail'><img src='" + lunchFood[i].Url + "' alt='Image' class='img-fluid'></a>";
                    display2 += "<h3><a href='Galary.aspx?name=" + lunchFood[i].Name + "&url=" + lunchFood[i].Url + "&price=" + lunchFood[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ lunchFood[i].Id + "&category="+ Security.Security.encrypt(lunchFood[i].Category) + "'>" + lunchFood[i].Name + "</a></h3>";
                    display2 += "<div class='d-flex'>";
                    display2 += "<div class='price'>R" + lunchFood[i].Price + "</div>";
                    display2 += "</div></div></div>";
                }
                else
                {
                    display2 += "<div class='col-6 col-lg-6 mb-0'>";
                    display2 += "<div class='product'>";
                    display2 += "<a href='Galary.aspx?name=" + lunchFood[i].Name + "&url=" + lunchFood[i].Url + "&price=" + lunchFood[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ lunchFood[i].Id + "&category="+ Security.Security.encrypt(lunchFood[i].Category) + "' class='thumbnail'><img src='" + lunchFood[i].Url + "' alt='Image' class='img-fluid'></a>";
                    display2 += "<h3><a href='Galary.aspx?name=" + lunchFood[i].Name + "&url=" + lunchFood[i].Url + "&price=" + lunchFood[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ lunchFood[i].Id + "&category="+ Security.Security.encrypt(lunchFood[i].Category) + "'>" + lunchFood[i].Name + "</a>" + lunchFood[i].Name + "</h3>";
                    display2 += "<div class='d-flex'>";
                    display2 += "<div class='price'>R" + lunchFood[i].Price + "</div>";
                    display2 += "</div></div></div>";
                }
            }
            lunch.InnerHtml = display2;
            string display1 = "";

            List<Food> dinnerFood = await foodController.listFood("Food/getFoods?category=dinner");
            for (int i = 0; i < dinnerFood.Count; i++)
            {

                if (i < 2)
                {
                    display1 += "<div class='col-6 col-lg-6 mb-4'>";
                    display1 += "<div class='product'>";
                    display1 += "<a href='Galary.aspx?name=" + dinnerFood[i].Name + "&url=" + dinnerFood[i].Url + "&price=" + dinnerFood[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ dinnerFood[i].Id + "&category="+ Security.Security.encrypt(dinnerFood[i].Category) + "' class='thumbnail'><img src='" + dinnerFood[i].Url + "' alt='Image' class='img-fluid'></a>";
                    display1 += "<h3><a href='Galary.aspx?name=" + dinnerFood[i].Name + "&url=" + dinnerFood[i].Url + "&price=" + dinnerFood[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ dinnerFood[i].Id + "&category="+ Security.Security.encrypt(dinnerFood[i].Category) + "'>" + dinnerFood[i].Name + "</a></h3>";
                    display1 += "<div class='d-flex'>";
                    display1 += "<div class='price'>R" + dinnerFood[i].Price + "</div>";
                    display1 += "</div></div></div>";
                }
                else
                {
                    display1 += "<div class='col-6 col-lg-6 mb-0'>";
                    display1 += "<div class='product'>";
                    display1 += "<a href='Galary.aspx?name=" + dinnerFood[i].Name + "&url=" + dinnerFood[i].Url + "&price=" + dinnerFood[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ dinnerFood[i].Id + "&category="+ Security.Security.encrypt(dinnerFood[i].Category) + "' class='thumbnail'><img src='" + dinnerFood[i].Url + "' alt='Image' class='img-fluid'></a>";
                    display1 += "<h3><a href='Galary.aspx?name=" + dinnerFood[i].Name + "&url=" + dinnerFood[i].Url + "&price=" + dinnerFood[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ dinnerFood[i].Id + "&category="+ Security.Security.encrypt(dinnerFood[i].Category) + "'>" + dinnerFood[i].Name + "</a>" + dinnerFood[i].Name + "</h3>";
                    display1 += "<div class='d-flex'>";
                    display1 += "<div class='price'>R" + dinnerFood[i].Price + "</div>";
                    display1 += "</div></div></div>";
                }
            }
            dinner.InnerHtml = display1;
            string display3 = "";

            List<Food> drinks = await foodController.listFood("Food/getFoods?category=drinks");
            for (int i = 0; i < drinks.Count; i++)
            {

                if (i < 2)
                {
                    display3 += "<div class='col-6 col-lg-6 mb-4'>";
                    display3 += "<div class='product'>";
                    display3 += "<a href='Galary.aspx?name=" + drinks[i].Name + "&url=" + drinks[i].Url + "&price=" + drinks[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ drinks[i].Id + "&category="+ Security.Security.encrypt(drinks[i].Category) + "' class='thumbnail'><img src='" + drinks[i].Url + "' alt='Image' class='img-fluid'></a>";
                    display3 += "<h3><a href='Galary.aspx?name=" + drinks[i].Name + "&url=" + drinks[i].Url + "&price=" + drinks[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ drinks[i].Id + "&category="+ Security.Security.encrypt(drinks[i].Category) + "'>" + drinks[i].Name + "</a></h3>";
                    display3 += "<div class='d-flex'>";
                    display3 += "<div class='price'>R" + drinks[i].Price + "</div>";
                    display3 += "</div></div></div>";
                }
                else
                {
                    display3 += "<div class='col-6 col-lg-6 mb-0'>";
                    display3 += "<div class='product'>";
                    display3 += "<a href='Galary.aspx?name=" + drinks[i].Name + "&url=" + drinks[i].Url + "&price=" + drinks[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ drinks[i].Id + "&category="+ Security.Security.encrypt(drinks[i].Category) + "' class='thumbnail'><img src='" + drinks[i].Url + "' alt='Image' class='img-fluid'></a>";
                    display3 += "<h3><a href='Galary.aspx?name=" + drinks[i].Name + "&url=" + drinks[i].Url + "&price=" + drinks[i].Price + "&U_ID="+Security.Security.encrypt("" + U_ID)+"&U_Type="+ Security.Security.encrypt(U_Type) + "&F_ID="+ drinks[i].Id + "&category="+ Security.Security.encrypt(drinks[i].Category) + "'>" + drinks[i].Name + "</a>" + drinks[i].Name + "</h3>";
                    display3 += "<div class='d-flex'>";
                    display3 += "<div class='price'>R" + drinks[i].Price + "</div>";
                    display3 += "</div></div></div>";
                }
            }
            drink.InnerHtml = display3;*/
        }
    }
}