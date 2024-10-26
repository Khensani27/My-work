using Elibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Elibrary.Controllers
{
    public class BorrowedBookController : Controller
    {

        private Base<Borrowed_Books> borrowed;

        public BorrowedBookController()
        {
            
            borrowed = new Base<Borrowed_Books>();
        }

        public async Task<HttpResponseMessage> AddBorrowed(string url, Object obj)
        {
            HttpResponseMessage u = await borrowed.Create(url, obj);
            return u;
        }

        public async Task<List<Borrowed_Books>> getBorrowedBooks(string url)
        {
            List<Borrowed_Books> u = await borrowed.GetAll(url);
            return u;
        }
    }
}