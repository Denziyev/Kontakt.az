using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kontakt.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductCreditTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCredit_Credits_CreditId",
                table: "ProductCredit");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCredit_Products_ProductId",
                table: "ProductCredit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCredit",
                table: "ProductCredit");

            migrationBuilder.RenameTable(
                name: "ProductCredit",
                newName: "ProductCredits");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCredit_ProductId",
                table: "ProductCredits",
                newName: "IX_ProductCredits_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCredit_CreditId",
                table: "ProductCredits",
                newName: "IX_ProductCredits_CreditId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCredits",
                table: "ProductCredits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCredits_Credits_CreditId",
                table: "ProductCredits",
                column: "CreditId",
                principalTable: "Credits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCredits_Products_ProductId",
                table: "ProductCredits",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCredits_Credits_CreditId",
                table: "ProductCredits");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCredits_Products_ProductId",
                table: "ProductCredits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCredits",
                table: "ProductCredits");

            migrationBuilder.RenameTable(
                name: "ProductCredits",
                newName: "ProductCredit");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCredits_ProductId",
                table: "ProductCredit",
                newName: "IX_ProductCredit_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCredits_CreditId",
                table: "ProductCredit",
                newName: "IX_ProductCredit_CreditId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCredit",
                table: "ProductCredit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCredit_Credits_CreditId",
                table: "ProductCredit",
                column: "CreditId",
                principalTable: "Credits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCredit_Products_ProductId",
                table: "ProductCredit",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
