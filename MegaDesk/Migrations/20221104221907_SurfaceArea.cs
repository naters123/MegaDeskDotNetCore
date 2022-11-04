using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDesk.Migrations
{
    public partial class SurfaceArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurfaceArea",
                table: "DeskQuote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SurfaceArea",
                table: "DeskQuote",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
