using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurvivorWebApiEF.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertyToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Categories_CategoryEntityId",
                table: "Competitors");

            migrationBuilder.DropIndex(
                name: "IX_Competitors_CategoryEntityId",
                table: "Competitors");

            migrationBuilder.DropColumn(
                name: "CategoryEntityId",
                table: "Competitors");

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_CategoryId",
                table: "Competitors",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Categories_CategoryId",
                table: "Competitors",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Categories_CategoryId",
                table: "Competitors");

            migrationBuilder.DropIndex(
                name: "IX_Competitors_CategoryId",
                table: "Competitors");

            migrationBuilder.AddColumn<int>(
                name: "CategoryEntityId",
                table: "Competitors",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_CategoryEntityId",
                table: "Competitors",
                column: "CategoryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Categories_CategoryEntityId",
                table: "Competitors",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
