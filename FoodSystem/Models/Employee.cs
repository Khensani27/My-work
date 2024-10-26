using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalYearWeb.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string DriverEmail { get; set; }
        public string DriverPictureUrl { get; set; }
        public int DriverRating { get; set; }
        public int DriverCompletedTrips { get; set; }
        public string DriverAddress { get; set; }
        public string DriverLanguages { get; set; }
    }
}