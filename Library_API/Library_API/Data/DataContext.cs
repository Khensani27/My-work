using Microsoft.EntityFrameworkCore;
using Library_API.Models;

namespace Library_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Admins> Admins { get; set; }

        public DbSet<Books> Books { get; set; }

        public DbSet<Borrowed_Books> Borrowed_Books { get; set; } 


    }
}
