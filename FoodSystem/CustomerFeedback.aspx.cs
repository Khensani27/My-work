using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class CustomerFeedback : System.Web.UI.Page
    {
        RatingController ratingController = new RatingController();
        protected async void Page_Load(object sender, EventArgs e)
        {

            List<Rating> ratings = await ratingController.getRating("Rating/getAllRatings");

            string display = "";

            if (ratings != null)
            {
                for (int i = 0; i < ratings.Count; i++)
                {
                    display += "<div class='col-lg-4 menu-item'>";
                    //display += "<a href='DetailsPage.aspx?name=" + ratings[i].feedback + foods[i].Category + "' class='glightbox'><img src='" + foods[i].Url + "' class='menu-img img-fluid' alt=''></a>";
                    display += "<h4> Order " + ratings[i].OrderId + "</h4>";
                    display += "<p class='ingredients'>Comment: " + ratings[i].feedback + "</p>";
                    //display += "<p class='price'> " + ratings[i].UserId + "</p>";
                    display += "<p> Delivery Rating: " + ratings[i].DeliveryRating + "</p>";
                    display += "<p> Order Rating: " + ratings[i].OrderRating + "</p>";
                    display += "<p> Service Rating: " + ratings[i].ServiceRating + "</p>";
                    display += "</div>";
                }
            }
            else
            {
                display += "<p>No feedback available.</p>";
            }
            feedback.InnerHtml = display;

        }

    }
}