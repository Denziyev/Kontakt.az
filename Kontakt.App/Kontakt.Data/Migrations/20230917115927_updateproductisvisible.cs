using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kontakt.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateproductisvisible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisibleinMenu",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisibleinMenu",
                table: "Products");
        }
    }
}
