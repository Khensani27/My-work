using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalYearWeb.Models
{
    public class OrderedItems
    {
        public int OrderId { get; set; }
        public List<string> FoodItems { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public decimal TotalCost { get; set; }
        public string OrderType { get; set; }
        public double AverageRating { get; set; }
        public int Count { get; set; }
        public string UserEmail { get; set; }
        public string UserContact { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderStatus { get; set; }
    }
}