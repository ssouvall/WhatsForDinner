using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class DeleteQuantityObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuantityObject");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "ShoppingListItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "ShoppingListItems",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "ShoppingListItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShoppingListItems");

            migrationBuilder.CreateTable(
                name: "QuantityObject",
                columns: table => new
                {
                    QuantityObjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    QuantityUnit = table.Column<string>(type: "TEXT", nullable: true),
                    ShoppingListItemId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityObject", x => x.QuantityObjectId);
                    table.ForeignKey(
                        name: "FK_QuantityObject_ShoppingListItems_ShoppingListItemId",
                        column: x => x.ShoppingListItemId,
                        principalTable: "ShoppingListItems",
                        principalColumn: "ShoppingListItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuantityObject_ShoppingListItemId",
                table: "QuantityObject",
                column: "ShoppingListItemId");
        }
    }
}
