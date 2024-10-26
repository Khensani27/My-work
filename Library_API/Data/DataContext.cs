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

        // Optional: Configure the database provider directly if not using DI
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseSqlServer("YourConnectionStringHere");
        //     }
        // }
    }
}
