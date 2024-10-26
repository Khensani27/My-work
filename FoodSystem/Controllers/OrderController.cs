using FinalYearWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace FinalYearWeb.Controllers
{
    public class OrderController
    {
        private Base<Order> order;

        public OrderController()
        {
            order = new Base<Order>();
        }

        public async Task<bool> placeOrder(string url, object obj)
        {
            try
            {
                if (obj != null)
                {
                    await order.Create(url, obj);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Models.Order>> getOrder(string url)
        {
            return await order.GetAll(url);
        }
        public async Task<Order> getSingleOrder(string url)
        {
            return await order.Get(url);
        }

        public async Task<HttpResponseMessage> updateOrderStatus(string url, object obj)
        {
            return await order.Edit(url, obj);
        }
    }
}