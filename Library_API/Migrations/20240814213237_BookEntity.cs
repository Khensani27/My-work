using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_API.Migrations
{
    /// <inheritdoc />
    public partial class BookEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Book_Status",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book_Status",
                table: "Books");
        }
    }
}
