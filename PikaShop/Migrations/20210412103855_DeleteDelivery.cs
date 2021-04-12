using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PikaShop.Migrations
{
    public partial class DeleteDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveries_id_delivery",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Orders_id_delivery",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "id_delivery",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_delivery",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    id_delivery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    end_delivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name_delivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price_delivery = table.Column<float>(type: "real", nullable: false),
                    start_delivery = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.id_delivery);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_delivery",
                table: "Orders",
                column: "id_delivery");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliveries_id_delivery",
                table: "Orders",
                column: "id_delivery",
                principalTable: "Deliveries",
                principalColumn: "id_delivery",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
