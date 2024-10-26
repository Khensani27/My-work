using FinalYearWeb.Controllers;
using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearWeb
{
    public partial class UpdateEmployeeInfo : System.Web.UI.Page
    {
        private int employeeID;
        private string employeeName;
        DeliveryPersonController controller = new DeliveryPersonController();
        protected async void Page_Load(object sender, EventArgs e)
        {
            employeeID = int.Parse(Request.QueryString["ID"].ToString());
            Employee employee = await controller.GetEmployee("Driver/getDriver?ID=" + employeeID);
            Session["Employee"] = employee;
            nameUpdate.Text = employee.Name;
            emailUpdate.Text = employee.DriverEmail;
            addressUpdate.Text = employee.DriverAddress;
            imageUpdate.Text = employee.DriverPictureUrl;
            languageUpdate.Text = employee.DriverLanguages;


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
            display += "<span>" + employee.DriverAddress + "</span>";
            display += "</div>";
            display += "</div>";
            display += "</div>";
            display += "</div>";
            display += "</section>";
            update.InnerHtml = display;

        }
        private string FilePath = "";
        protected void btnUpload(object sender, EventArgs e)
        {
            FileUpload1.SaveAs(Server.MapPath("~/images/" + FileUpload1.FileName));
            Status.Text = "File Uploaded";
            Status.ForeColor = System.Drawing.Color.Gray;
            FilePath = "images/" + FileUpload1.FileName;

            Session["ImagePath"] = FilePath;

            Session["Flag"] = "true";

        }


        /*protected async void btnUpdateMenu(object sender, EventArgs e)
        {

            Employee newE = Session["Employee"] as Employee;
            Employee emp;

            string fileP = Session["ImagePath"] as string;
            

            string ImageChange = Session["Flag"] as string;

            if (ImageChange.Equals("true"))
            {
                emp = new Employee()
                {
                    Id = newE.Id,
                    Name = nameUpdate.Text,
                    DriverEmail = emailUpdate.Text,
                    DriverAddress = addressUpdate.Text,
                    DriverPictureUrl = fileP,
                    DriverLanguages = languageUpdate.Text
                };

            }
            else
            {
                emp = new Employee()
                {
                    Id = newE.Id,
                    Name = nameUpdate.Text,
                    DriverEmail = emailUpdate.Text,
                    DriverAddress = addressUpdate.Text,
                    DriverPictureUrl = newE.DriverPictureUrl,
                    DriverLanguages = languageUpdate.Text
                };
            }



            HttpResponseMessage responce = await controller.EditEmployee("Driver/updateDriverById?ID=" + emp.Id +
                "&nameU=" + emp.Name + "&emailU=" + emp.DriverEmail + "&addressU=" + emp.DriverAddress + "&imageURL=" +
                emp.DriverPictureUrl + "&language=" + emp.DriverLanguages, emp);
            if (responce != null)
            {
                string display = "";
                display += "<section class='about_part'>";
                display += "<div class='container-fluid'>";
                display += "<div class='row align-items-center'>";
                display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
                display += "<div class='about_img'>";
                display += "<img src='" + emp.DriverPictureUrl + "' alt='' height='400' width='250'/>";
                display += "</div>";
                display += "</div>";
                display += "<div class='col-sm-8 col-lg-4'>";
                display += "<div class='about_text'>";
                display += "<h5>" + emp.Name + "</h5>";
                display += "<p>" + emp.DriverEmail + "</p>";
                display += "<span>" + emp.DriverAddress + "</span>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</div>";
                display += "</section>";
                update.InnerHtml = display;
            }

        } */

        protected async void btnUpdateMenu(object sender, EventArgs e)
        {

            Employee newE = Session["Employee"] as Employee;
            Employee emp;

            string fileP = Session["ImagePath"] as string;


            string ImageChange = Session["Flag"] as string;

            if (ImageChange.Equals("true"))
            {
                emp = new Employee()
                {
                    Id = newE.Id,
                    Name = nameUpdate.Text,
                    DriverEmail = emailUpdate.Text,
                    DriverAddress = addressUpdate.Text,
                    DriverPictureUrl = fileP,
                    DriverLanguages = languageUpdate.Text
                };

            }
            else
            {
                emp = new Employee()
                {
                    Id = newE.Id,
                    Name = nameUpdate.Text,
                    DriverEmail = emailUpdate.Text,
                    DriverAddress = addressUpdate.Text,
                    DriverPictureUrl = newE.DriverPictureUrl,
                    DriverLanguages = languageUpdate.Text
                };
            }



            HttpResponseMessage responce = await controller.EditEmployee("Driver/updateDriverById?ID=" + emp.Id +
                "&nameU=" + emp.Name + "&emailU=" + emp.DriverEmail + "&addressU=" + emp.DriverAddress + "&imageURL=" +
                emp.DriverPictureUrl + "&language=" + emp.DriverLanguages, emp);
            if (responce != null)
            {
                string display = "";
                display += "<section class='about_part'>";
                display += "<div class='container-fluid'>";
                display += "<div class='row align-items-center'>";
                display += "<div class='col-sm-4 col-lg-5 offset-lg-1'>";
                display += "<div class='about_img'>";
                display += "<img src='" + emp.DriverPictureUrl + "' alt='' height='400' width='250'/>";
                display += "</div>";
                display += "</div>";
                display += "<div class='col-sm-8 col-lg-4'>";
                display += "<div class='about_text'>";
                display += "<h5>" + emp.Name + "</h5>";
                display += "<p>" + emp.DriverEmail + "</p>";
                display += "<span>" + emp.DriverAddress + "</span>";
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