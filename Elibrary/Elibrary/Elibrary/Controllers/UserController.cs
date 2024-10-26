using Elibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace Elibrary.Controllers
{
    public class UserController
    {
        private Base<Users> user;

        public UserController()
        {
            user = new Base<Users>();
        }

        public async Task<Users> logIn(string url)
        {
            Users u = await user.Get(url);
            return u;
        }
        public async Task<HttpResponseMessage> register(string url, Object obj)
        {
            HttpResponseMessage u = await user.Create(url, obj);
            return u;
        }

        public async Task<Users> getUserById(string userId)
        {
            string url = "https://libraryapi-hxbwaxb4bdfkcvg9.southafricanorth-01.azurewebsites.net/api/User/getUserByID?id=" + userId;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var userJson = await response.Content.ReadAsStringAsync();
                    // Deserialize the JSON response to a Users object
                    Users user = Newtonsoft.Json.JsonConvert.DeserializeObject<Users>(userJson);
                    return user;
                }
                else
                {
                    // Handle error (e.g., if the user is not found)
                    return null;
                }
            }
        }


        public async Task<bool> DoesEmailExist(string email)
        {
            string url = $"User/doesEmailExist?email={HttpUtility.UrlEncode(email)}";
            return await user.GetBool(url);
        }

    }
}