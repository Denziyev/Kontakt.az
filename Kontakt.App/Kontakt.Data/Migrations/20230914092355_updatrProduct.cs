using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kontakt.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatrProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCount",
                table: "Products");
        }
    }
}
