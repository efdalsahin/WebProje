using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyPioneer.Migrations
{
    public partial class havalimaniulke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ulke",
                table: "HavaAlanlari",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ulke",
                table: "HavaAlanlari");
        }
    }
}
