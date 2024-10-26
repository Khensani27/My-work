using Elibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Elibrary.Controllers
{
    public class AdminController 
    {
        private Base<Admins> admin;

        public AdminController()
        {
            admin = new Base<Admins>();
        }

        public async Task<Admins> logIn(string url)
        {
            Admins u = await admin.Get(url);
            return u;
        }
    }
}