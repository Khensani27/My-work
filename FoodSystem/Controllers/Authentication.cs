using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using FinalYearWeb.Models;

namespace FinalYearWeb.Controllers
{
    public class Authentication
    {
        private Base<Users> user;

        public Authentication()
        {
            user = new Base<Users>();
        }
        public async Task<Users> logIn(string url)
        {
            Users u = await user.Get(url);
            return u;
        }

        public async Task<List<Users>> GetUsers(string url)
        {
            List<Users> file = await user.GetAll(url);
            return file;
        }

        public async Task<HttpResponseMessage> register(string url, Object obj)
        {
            HttpResponseMessage u = await user.Create(url, obj);
            return u;
        }

    }
}