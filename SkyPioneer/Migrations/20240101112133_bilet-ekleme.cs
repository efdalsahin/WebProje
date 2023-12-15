using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyPioneer.Migrations
{
    public partial class biletekleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biletler",
                columns: table => new
                {
                    BiletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    UcusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biletler", x => x.BiletId);
                    table.ForeignKey(
                        name: "FK_Biletler_Kullancilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullancilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Biletler_Ucuslar_UcusID",
                        column: x => x.UcusID,
                        principalTable: "Ucuslar",
                        principalColumn: "UcusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biletler_KullaniciID",
                table: "Biletler",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Biletler_UcusID",
                table: "Biletler",
                column: "UcusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biletler");
        }
    }
}
