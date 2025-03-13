using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaMiro.Migrations
{
    /// <inheritdoc />
    public partial class updet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is_active",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "Is_active",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
