using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class ThankYou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Payment_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("TrackOrder.aspx"); // Redirect to the TrackOrder page

        }
    }
}