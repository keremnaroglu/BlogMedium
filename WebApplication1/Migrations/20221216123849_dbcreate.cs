using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dbcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resim = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Konular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonuAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makaleler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KisiId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makaleler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Makaleler_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KonuMakale",
                columns: table => new
                {
                    KonularId = table.Column<int>(type: "int", nullable: false),
                    MakalelerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonuMakale", x => new { x.KonularId, x.MakalelerId });
                    table.ForeignKey(
                        name: "FK_KonuMakale_Konular_KonularId",
                        column: x => x.KonularId,
                        principalTable: "Konular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KonuMakale_Makaleler_MakalelerId",
                        column: x => x.MakalelerId,
                        principalTable: "Makaleler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KonuMakale_MakalelerId",
                table: "KonuMakale",
                column: "MakalelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Makaleler_KisiId",
                table: "Makaleler",
                column: "KisiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KonuMakale");

            migrationBuilder.DropTable(
                name: "Konular");

            migrationBuilder.DropTable(
                name: "Makaleler");

            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}
