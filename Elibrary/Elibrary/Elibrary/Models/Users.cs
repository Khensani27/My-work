using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elibrary.Models
{
        public class Users
        {
        public int Id { get; set; }
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public string Contact_No { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Account_Status { get; set; } = string.Empty;
    }
    

}