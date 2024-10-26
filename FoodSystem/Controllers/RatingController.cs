using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FinalYearWeb.Controllers
{
    public class RatingController
    {
        private Base<Rating> order;

        public RatingController()
        {
            order = new Base<Rating>();
        }

        public async Task<HttpResponseMessage> addRatings(string url, Object obj)
        {
            HttpResponseMessage u = await order.Create(url, obj);
            return u;
        }
        public async Task<List<Rating>> getRating(string url)
        {
            return await order.GetAll(url);
        }

    }
}