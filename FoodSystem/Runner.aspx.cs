using FinalYearWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class Runner : System.Web.UI.Page
    {
        private FoodController foodController = new FoodController();
        private Authentication authController = new Authentication();
        protected async void Page_Load(object sender, EventArgs e)
        {
            int U_ID = 1;
            List<Models.Cart> cartList = await foodController.getcarts("Food/getCarts?U_ID=" + U_ID);
            List<Models.Users> userlist = await authController.GetUsers("User/getUsers");
            string display = "";
            foreach (Models.Cart c in cartList)
            {
                display += "<tr>";
                display += "<th scope='row'> <a href='#' class='question_content'>Daneil Marks</a></th>";
                display += "<td>Protea Glen, Ext 4, 254 fox street</td>";
                display += "<td><a href='#' class='status_btn'>Active</a></td>";
                display += "</tr>";
            }
            table.InnerHtml = display;
        }
    }
}