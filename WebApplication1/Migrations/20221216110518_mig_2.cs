using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KisiId",
                table: "Makaleler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Makaleler_KisiId",
                table: "Makaleler",
                column: "KisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Makaleler_Kisiler_KisiId",
                table: "Makaleler",
                column: "KisiId",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Makaleler_Kisiler_KisiId",
                table: "Makaleler");

            migrationBuilder.DropIndex(
                name: "IX_Makaleler_KisiId",
                table: "Makaleler");

            migrationBuilder.DropColumn(
                name: "KisiId",
                table: "Makaleler");
        }
    }
}
