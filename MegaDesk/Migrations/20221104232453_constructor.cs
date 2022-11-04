using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDesk.Migrations
{
    public partial class constructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinalPrice",
                table: "DeskQuote",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "DeskQuote");
        }
    }
}
