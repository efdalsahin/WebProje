using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyPioneer.Migrations
{
    public partial class ucus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ucuslar_HavaAlanlari_VarisHavaAlaniID",
                table: "Ucuslar");

            migrationBuilder.RenameColumn(
                name: "VarisHavaAlaniID",
                table: "Ucuslar",
                newName: "VarisID");

            migrationBuilder.RenameIndex(
                name: "IX_Ucuslar_VarisHavaAlaniID",
                table: "Ucuslar",
                newName: "IX_Ucuslar_VarisID");

            migrationBuilder.AddColumn<int>(
                name: "KaklisID",
                table: "Ucuslar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ucuslar_HavaAlanlari_VarisID",
                table: "Ucuslar",
                column: "VarisID",
                principalTable: "HavaAlanlari",
                principalColumn: "HavaAlaniID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ucuslar_HavaAlanlari_VarisID",
                table: "Ucuslar");

            migrationBuilder.DropColumn(
                name: "KaklisID",
                table: "Ucuslar");

            migrationBuilder.RenameColumn(
                name: "VarisID",
                table: "Ucuslar",
                newName: "VarisHavaAlaniID");

            migrationBuilder.RenameIndex(
                name: "IX_Ucuslar_VarisID",
                table: "Ucuslar",
                newName: "IX_Ucuslar_VarisHavaAlaniID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ucuslar_HavaAlanlari_VarisHavaAlaniID",
                table: "Ucuslar",
                column: "VarisHavaAlaniID",
                principalTable: "HavaAlanlari",
                principalColumn: "HavaAlaniID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
