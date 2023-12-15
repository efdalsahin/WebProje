using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyPioneer.Migrations
{
    public partial class biletkoltukno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KoltukNo",
                table: "Biletler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KoltukNo",
                table: "Biletler");
        }
    }
}
