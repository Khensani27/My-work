using FinalYearWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class CheckOut : System.Web.UI.Page
    {
        int U_ID;
        FoodController FoodController = new FoodController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnToPayment(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx");
        }

    }
}