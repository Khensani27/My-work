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
    public partial class EmployeeManagement : System.Web.UI.Page
    {
        DeliveryPersonController controller = new DeliveryPersonController();
        protected async void Page_Load(object sender, EventArgs e)
        {
            List<Employee> employees = await controller.GetAllEmployees("Driver/getAllDrivers");
            string display = "";

            if (employees != null)
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    display += "<div class='job-item p-4 mb-4'>";
                    display += "<div class='row g-4'>";
                    display += "<div class='col-sm-12 col-md-8 d-flex align-items-center'>";
                    display += "<img class='flex-shrink-0 img-fluid border rounded' src='" + employees[i].DriverPictureUrl + "' alt='' style='width: 200px; height: 200px;'/>";
                    display += "<div class='text-start ps-4'>";
                    display += "<h5 class='mb-3'>" + employees[i].Name + "</h5>";
                    display += "<span class='text-truncate me-3'> Employee Address: " + employees[i].DriverAddress + "</span>";
                    display += "<span class='text-truncate me-3'> Email: " + employees[i].DriverEmail + "</span>";
                    //display += "<span class='text-truncate me-3'> Rating: " + employees[i].DriverRating + "</span>";
                    display += "<p> Rating: " + employees[i].DriverRating + "      Total Trips: " + employees[i].DriverCompletedTrips + "</p>";

                    // display += "<span class='text-truncate me-0' style='font-size:20px;color:green'> Rating: " + employees[i].DriverRating + "</span>";
                    //display += "<span class='text-truncate me-3'> Total Trips : " + employees[i].DriverCompletedTrips + "</span>";
                    display += "<p>";
                    display += "<a class='btn-book-a-table' style='background-color: forestgreen;color: black;width: 150px' href='DeleteEmployee.aspx?ID=" + employees[i].Id + "'>Remove Employee</a>";
                    display += "</p>";
                    display += "<a class='btn-book-a-table' style='background-color: forestgreen;color: black;width: 150px' href='UpdateEmployeeInfo.aspx?ID=" + employees[i].Id + "'>Update Employee Information</a>";
                    display += "</div>";
                    display += "</div>";
                    display += "</div>";
                    display += "</div>";
                }
            }
            else
            {
                display += "<p> No Employees exist at the moment </p>";
            }
            displayAll.InnerHtml = display;
        }
    }
}