using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication_proiect.DAL.Migrations
{
    public partial class AddedPhotographerExhibitionManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotographerExhibitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotographerId = table.Column<int>(type: "int", nullable: false),
                    ExhibitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographerExhibitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotographerExhibitions_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotographerExhibitions_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotographerExhibitions_ExhibitionId",
                table: "PhotographerExhibitions",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotographerExhibitions_PhotographerId",
                table: "PhotographerExhibitions",
                column: "PhotographerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotographerExhibitions");
        }
    }
}
