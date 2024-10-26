namespace Library_API.Models
{
    public class Users
    {
        public int Id { get; set; }  // This is the primary key
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Contact_No { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Account_Status { get; set; }
    }
}
