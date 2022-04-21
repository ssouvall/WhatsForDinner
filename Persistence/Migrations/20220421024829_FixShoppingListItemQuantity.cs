using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixShoppingListItemQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "ShoppingListItems",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuantityUnit",
                table: "ShoppingListItems",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityUnit",
                table: "ShoppingListItems");

            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "ShoppingListItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
