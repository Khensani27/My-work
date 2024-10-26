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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected async void btnRegister(object sender, EventArgs e)
        {
            Authentication auth = new Authentication();
            Users user = new Users()
            {
                U_Email = email.Text,
                U_Password = password.Text,
                U_CellNumber = phone.Text,
                U_name = name.Text,
                U_type = "runner",
                U_username = surname.Text,
            };
            HttpResponseMessage response = await auth.register("User/addUser", user);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    lblName.Text = "Name : " + name.Text;
                    lblSurname.Text = "Surname : " + surname.Text;
                    lblEmail.Text = "Email Address : " + email.Text;
                    lblPhone.Text = "Phone Number : " + phone.Text;
                }
            }
        }
    }
}