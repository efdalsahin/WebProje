using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyPioneer.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HavaAlanlari",
                columns: table => new
                {
                    HavaAlaniID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HavaAlanlari", x => x.HavaAlaniID);
                });

            migrationBuilder.CreateTable(
                name: "HavaYollari",
                columns: table => new
                {
                    HavaYoluID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulke = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HavaYollari", x => x.HavaYoluID);
                });

            migrationBuilder.CreateTable(
                name: "Kullancilar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoyIsim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailAdres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yetki = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullancilar", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "Ucaklar",
                columns: table => new
                {
                    UcakID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kapasite = table.Column<int>(type: "int", nullable: false),
                    HavaYoluID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucaklar", x => x.UcakID);
                    table.ForeignKey(
                        name: "FK_Ucaklar_HavaYollari_HavaYoluID",
                        column: x => x.HavaYoluID,
                        principalTable: "HavaYollari",
                        principalColumn: "HavaYoluID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ucuslar",
                columns: table => new
                {
                    UcusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KalkisSaati = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KalkisHavaAlaniID = table.Column<int>(type: "int", nullable: false),
                    VarisHavaAlaniID = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<int>(type: "int", nullable: false),
                    UcakID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucuslar", x => x.UcusID);
                    table.ForeignKey(
                        name: "FK_Ucuslar_HavaAlanlari_KalkisHavaAlaniID",
                        column: x => x.KalkisHavaAlaniID,
                        principalTable: "HavaAlanlari",
                        principalColumn: "HavaAlaniID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ucuslar_HavaAlanlari_VarisHavaAlaniID",
                        column: x => x.VarisHavaAlaniID,
                        principalTable: "HavaAlanlari",
                        principalColumn: "HavaAlaniID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ucuslar_Ucaklar_UcakID",
                        column: x => x.UcakID,
                        principalTable: "Ucaklar",
                        principalColumn: "UcakID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ucaklar_HavaYoluID",
                table: "Ucaklar",
                column: "HavaYoluID");

            migrationBuilder.CreateIndex(
                name: "IX_Ucuslar_KalkisHavaAlaniID",
                table: "Ucuslar",
                column: "KalkisHavaAlaniID");

            migrationBuilder.CreateIndex(
                name: "IX_Ucuslar_UcakID",
                table: "Ucuslar",
                column: "UcakID");

            migrationBuilder.CreateIndex(
                name: "IX_Ucuslar_VarisHavaAlaniID",
                table: "Ucuslar",
                column: "VarisHavaAlaniID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullancilar");

            migrationBuilder.DropTable(
                name: "Ucuslar");

            migrationBuilder.DropTable(
                name: "HavaAlanlari");

            migrationBuilder.DropTable(
                name: "Ucaklar");

            migrationBuilder.DropTable(
                name: "HavaYollari");
        }
    }
}
