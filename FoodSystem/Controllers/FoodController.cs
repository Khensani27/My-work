using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FinalYearWeb.Controllers
{
   
    public class FoodController
    {
        private Base<Food> food;
        private Base<FinalYearWeb.Models.Cart> cart;

        public FoodController()
        {
            food = new Base<Food>();
            cart = new Base<FinalYearWeb.Models.Cart>();
        }
        public async Task<List<Food>> listFood(string url)
        {
            return await food.GetAll(url);
        }

        public async Task<Food> getFood(string url)
        {
            return await food.Get(url);
        }
        public async Task<FinalYearWeb.Models.Cart> getcart(string url)
        {
            return await cart.Get(url);
        }

        public async Task<HttpResponseMessage> updateCart(string url, Object obj)
        {
            return await cart.Edit(url, obj);
        }
        public async Task<HttpResponseMessage> addCart(string url, Object obj)
        {
            return await cart.Create(url, obj);
        }
        public async Task<List<FinalYearWeb.Models.Cart>> getcarts(string url)
        {
            return await cart.GetAll(url);
        }
    }
}