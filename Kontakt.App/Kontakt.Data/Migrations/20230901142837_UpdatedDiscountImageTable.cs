using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kontakt.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDiscountImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountsImages_DiscountsCategories_CategoryId",
                table: "DiscountsImages");

            migrationBuilder.DropIndex(
                name: "IX_DiscountsImages_CategoryId",
                table: "DiscountsImages");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DiscountsImages");

            migrationBuilder.AddColumn<int>(
                name: "DiscountCategoryId",
                table: "DiscountsImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DiscountsImages_DiscountCategoryId",
                table: "DiscountsImages",
                column: "DiscountCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountsImages_DiscountsCategories_DiscountCategoryId",
                table: "DiscountsImages",
                column: "DiscountCategoryId",
                principalTable: "DiscountsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountsImages_DiscountsCategories_DiscountCategoryId",
                table: "DiscountsImages");

            migrationBuilder.DropIndex(
                name: "IX_DiscountsImages_DiscountCategoryId",
                table: "DiscountsImages");

            migrationBuilder.DropColumn(
                name: "DiscountCategoryId",
                table: "DiscountsImages");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DiscountsImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiscountsImages_CategoryId",
                table: "DiscountsImages",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountsImages_DiscountsCategories_CategoryId",
                table: "DiscountsImages",
                column: "CategoryId",
                principalTable: "DiscountsCategories",
                principalColumn: "Id");
        }
    }
}
