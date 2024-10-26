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
    public partial class Register : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected async void login_Click(object sender, EventArgs e)
        {
            Authentication auth = new Authentication();
            Users user = new Users()
            {
                U_Email = txtEmail.Text,
                U_Password = txtPassword.Text,
                U_CellNumber = txtPhone.Text,
                U_name = txtFirstName.Text,
                U_type = "customer",
                U_username = txtSurname.Text,
            };
            HttpResponseMessage response = await auth.register("User/addUser", user);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}