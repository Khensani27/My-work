namespace Library_API.Models
{
    public class Admins
    {

        public int Id { get; set; }  // This is the primary key
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
