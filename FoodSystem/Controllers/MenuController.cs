using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FinalYearWeb.Controllers
{
    public class MenuController
    {
        private Base<Food> food;

        public MenuController()
        {
            food = new Base<Food>();
        }

        public async Task<HttpResponseMessage> CreateNewItem(string url, Object obj)
        {
            HttpResponseMessage u = await food.Create(url, obj);
            return u;
        }

        public async Task<Food> GetItem(string url)
        {
            Food u = await food.Get(url);
            return u;
        }

        public async Task<bool> DeleteItem(string url, Object obj)
        {
         
            return await food.Delete(url, obj);
        }

        public async Task<List<Food>> AllGetMenu(string url)
        {
            List<Food> menu = await food.GetAll(url);
            return menu;
        }

        public async Task<HttpResponseMessage> updateMenu(string url, Object obj)
        {
            return await food.Edit(url,obj);
        }
    }
}