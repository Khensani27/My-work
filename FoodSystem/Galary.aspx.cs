using FinalYearWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class Galary : System.Web.UI.Page
    {
       private FoodController foodController = new FoodController();
        private string name;
        private string url;
        private decimal price;
        private int U_ID;
        private string U_Type;
        private int F_ID;
        private string category;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = Request.QueryString["name"].ToString();
            url = Request.QueryString["url"].ToString();
            price =  Decimal.Parse(Request.QueryString["price"].ToString());
            U_ID = Int32.Parse(Security.Security.decrypt(Request.QueryString["U_ID"].ToString()));
            U_Type = Security.Security.decrypt(Request.QueryString["U_Type"].ToString());
            F_ID = Int32.Parse(Request.QueryString["F_ID"].ToString());
            category = Security.Security.decrypt(Request.QueryString["category"].ToString());
            string display = "";
            display += "<a href='images/img_1.jpg' data-fancybox='gallery' class='gal'><img src='"+url+"' style='width:300px' alt='Image' class='img-fluid'></a>";
            singleItemImg.InnerHtml = display;
            lblName.Text = name + " (R"+price+")";

        }

        protected void login_Click(object sender, EventArgs e)
        {

            Response.Redirect("Cart.aspx?name=" + name + "&url=" + url + "&price=" + price+"&quantity=" + txtQuantity.Text + "&U_ID=" + Security.Security.encrypt(""+U_ID) +"&F_ID="+ Security.Security.encrypt(""+F_ID) + "&category=" + Security.Security.encrypt(category)+"&U_Type=" + U_Type);
        }
    }
}