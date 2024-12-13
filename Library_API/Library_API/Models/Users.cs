﻿using System.ComponentModel.DataAnnotations;

namespace Library_API.Models
{
    public class Users
    {
        [Key]
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
