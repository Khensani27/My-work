using System.ComponentModel.DataAnnotations;

namespace Library_API.Models
{
    public class Books
    {

        [Key]
        public int Id { get; set; }// This is the primary key

        public int Actual_Stock { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public string Edition { get; set; } = string.Empty;

        public string Publisher { get; set; } = string.Empty;

        public string Publication_Date { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Book_Status { get; set; } = string.Empty;

        
    }
}
