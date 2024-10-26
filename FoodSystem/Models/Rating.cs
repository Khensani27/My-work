using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalYearWeb.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int OrderRating { get; set; }
        public int DeliveryRating { get; set; }
        public int ServiceRating { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public string feedback { get; set; } = string.Empty;
    }
}