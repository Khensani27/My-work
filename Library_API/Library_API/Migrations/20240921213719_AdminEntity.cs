using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_API.Migrations
{
    public partial class AdminEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the Admins table
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),  // Auto-incremented primary key
                    Email = table.Column<string>(nullable: false), // Email column
                    Password = table.Column<string>(nullable: false) // Password column
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id); // Primary key
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the Admins table if the migration is rolled back
            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
