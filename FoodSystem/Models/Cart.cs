using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalYearWeb.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int U_ID { get; set; }
        public int F_ID { get; set; }
        public string Url { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}