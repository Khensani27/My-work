using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TotalAmount"] != null)
                {
                    decimal totalAmount = Convert.ToDecimal(Session["TotalAmount"]);
                    totalAmountLabel.Text = "Total Amount: R" + totalAmount.ToString();

                }
                else
                {
                    totalAmountLabel.Text = "Total Amount: R0.00";
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["cart"] is string cartString)
            {
                var cart = JsonConvert.DeserializeObject<List<Order>>(cartString);
                //OrderController orderController = new OrderController();
                Response.Redirect("TrackOrder.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }


        protected string getAllCartValues()
        {
            if (Session["cart"] is string cartString)
            {
                return cartString;
            }
            else
            {
                return "";
            }
        }




    }
}