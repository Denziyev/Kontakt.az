using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kontakt.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedBrandCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CategoryId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Brands");

            migrationBuilder.CreateTable(
                name: "categoryBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoryBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoryBrands_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoryBrands_BrandId",
                table: "categoryBrands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_categoryBrands_CategoryId",
                table: "categoryBrands",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoryBrands");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CategoryId",
                table: "Brands",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                table: "Brands",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
