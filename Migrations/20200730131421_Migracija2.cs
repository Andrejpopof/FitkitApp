using Microsoft.EntityFrameworkCore.Migrations;

namespace FitKitApp.Migrations
{
    public partial class Migracija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObemBiceps",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "ObemLevBiceps",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObemLevBiceps",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "ObemBiceps",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
