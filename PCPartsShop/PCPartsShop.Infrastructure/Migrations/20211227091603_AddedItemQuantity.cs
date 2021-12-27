using Microsoft.EntityFrameworkCore.Migrations;

namespace PCPartsShop.Infrastructure.Migrations
{
    public partial class AddedItemQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderItemQuantity",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderItemQuantity",
                table: "OrderItems");
        }
    }
}
