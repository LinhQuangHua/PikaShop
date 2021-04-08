using Microsoft.EntityFrameworkCore.Migrations;

namespace PikaShop.Migrations
{
    public partial class AddTotalSartInRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "totalStar",
                table: "RatingProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalStar",
                table: "RatingProducts");
        }
    }
}
