using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Elibrary.Models
{
    public class Borrowed_Books
    {
        public int Borrowed_ID { get; set; }// This is the primary key
        public int User_ID { get; set; } //This is the foreign key.

        public int Book_ID { get; set; } //This is the foreign key.

        public DateTime Borrowed_Date { get; set; }

        public DateTime Returned_Date { get; set; }

        public Double Fine { get; set; }

       public String Book_Status { get; set; } = string.Empty;
    }
}