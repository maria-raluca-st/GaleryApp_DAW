using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication_proiect.DAL.Migrations
{
    public partial class AddedGalleryExhibitionOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Exhibitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exhibitions_GalleryId",
                table: "Exhibitions",
                column: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibitions_Galleries_GalleryId",
                table: "Exhibitions",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exhibitions_Galleries_GalleryId",
                table: "Exhibitions");

            migrationBuilder.DropIndex(
                name: "IX_Exhibitions_GalleryId",
                table: "Exhibitions");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Exhibitions");
        }
    }
}
