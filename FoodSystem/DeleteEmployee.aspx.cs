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
    public partial class DeleteEmployee : System.Web.UI.Page
    {
        DeliveryPersonController controller = new DeliveryPersonController();
        private int empolyeeID;
        protected async void Page_Load(object sender, EventArgs e)
        {

            empolyeeID = int.Parse(Request.QueryString["ID"].ToString());
            Employee employee = await controller.GetEmployee("Driver/getDriver?ID=" + empolyeeID);
            Session["Employee"] = employee;

            string display = "";
            display += "<section class='about_part'>";
            display += "<div class='container-fluid'>";
            display += "<div class='row align-items-center'>";
            display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
            display += "<div class='about_img'>";
            display += "<img src='" + employee.DriverPictureUrl + "' alt='' height='400' width='250'/>";
            display += "</div>";
            display += "</div>";
            display += "<div class='col-sm-8 col-lg-4'>";
            display += "<div class='about_text'>";
            display += "<h5>" + employee.Name + "</h5>";
            display += "<p>" + employee.DriverEmail + "</p>";
            display += "<span>" + employee.DriverRating + "</span>";
            display += "</div>";
            display += "</div>";
            display += "</div>";
            display += "</div>";
            display += "</section>";
            update.InnerHtml = display;

        }

        protected async void btnDelete(object sender, EventArgs e)
        {
            Employee empD = Session["Employee"] as Employee;

            bool results = await controller.RemoveEmployee("Driver/removeDriver?request=" + empD.Id, empD);
            if (results == true)
            {
                string display = "";
                display += "<section class='about_part'>";
                display += "<div class='container-fluid'>";
                display += "<div class='row align-items-center'>";
                display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
                display += "<div class='about_img'>";
                display += "<img src='images/account.JPG' alt='' height='400' width='250'/>";
                display += "</div>";
                display += "</div>";
                display += "<div class='col-sm-8 col-lg-4'>";
                display += "<div class='about_text'>";
                display += "<h5> Employee Removed </h5>";
                display += "<p> Employee Removed </p>";
                display += "<span> </span>";
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