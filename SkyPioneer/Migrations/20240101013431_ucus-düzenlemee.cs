using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyPioneer.Migrations
{
    public partial class ucusdüzenlemee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ucuslar_HavaAlanlari_KalkisHavaAlaniID",
                table: "Ucuslar");

            migrationBuilder.DropColumn(
                name: "KaklisID",
                table: "Ucuslar");

            migrationBuilder.RenameColumn(
                name: "KalkisHavaAlaniID",
                table: "Ucuslar",
                newName: "KalkisID");

            migrationBuilder.RenameIndex(
                name: "IX_Ucuslar_KalkisHavaAlaniID",
                table: "Ucuslar",
                newName: "IX_Ucuslar_KalkisID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ucuslar_HavaAlanlari_KalkisID",
                table: "Ucuslar",
                column: "KalkisID",
                principalTable: "HavaAlanlari",
                principalColumn: "HavaAlaniID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ucuslar_HavaAlanlari_KalkisID",
                table: "Ucuslar");

            migrationBuilder.RenameColumn(
                name: "KalkisID",
                table: "Ucuslar",
                newName: "KalkisHavaAlaniID");

            migrationBuilder.RenameIndex(
                name: "IX_Ucuslar_KalkisID",
                table: "Ucuslar",
                newName: "IX_Ucuslar_KalkisHavaAlaniID");

            migrationBuilder.AddColumn<int>(
                name: "KaklisID",
                table: "Ucuslar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ucuslar_HavaAlanlari_KalkisHavaAlaniID",
                table: "Ucuslar",
                column: "KalkisHavaAlaniID",
                principalTable: "HavaAlanlari",
                principalColumn: "HavaAlaniID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
