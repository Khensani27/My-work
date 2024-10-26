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
            migrationBuilder.AddColumn<int>(
                name: "Actual_Stock",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actual_Stock",
                table: "Books");
        }
    }
}
