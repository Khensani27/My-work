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
    public class BookController
    {
        private Base<Books> book;
        private Base<Borrowed_Books> borrowed;

        public BookController()
        {
            book = new Base<Books>();
            borrowed = new Base<Borrowed_Books>();
        }

        public async Task<List<Books>> AllBooks(string url)
        {    
           List<Books> u = await book.GetAll(url);
            return u;
        }

        public async Task<HttpResponseMessage> updateBooks(string url, Object obj)
        {
            return await book.Edit(url, obj);
        }

        public async Task<Books> logIn(string id)
        {
            Books u = await book.Get(id);
            return u;
        }


        public async Task<HttpResponseMessage> register(string url, Object obj)
        {
            HttpResponseMessage u = await book.Create(url, obj);
            return u;
        }


     




    }
}