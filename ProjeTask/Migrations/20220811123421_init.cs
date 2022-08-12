using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjeTask.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fiyatlar",
                columns: table => new
                {
                    FiyatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dolar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Euro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sterlin = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiyatlar", x => x.FiyatId);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DTarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankaHesaplari",
                columns: table => new
                {
                    BankaHesapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EuroHesap = table.Column<long>(type: "bigint", nullable: false),
                    DolarHesap = table.Column<long>(type: "bigint", nullable: false),
                    SterlinHesap = table.Column<long>(type: "bigint", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankaHesaplari", x => x.BankaHesapId);
                    table.ForeignKey(
                        name: "FK_BankaHesaplari_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankaHesaplari_KullaniciId",
                table: "BankaHesaplari",
                column: "KullaniciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankaHesaplari");

            migrationBuilder.DropTable(
                name: "Fiyatlar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
