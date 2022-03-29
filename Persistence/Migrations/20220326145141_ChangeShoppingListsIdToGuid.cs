using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangeShoppingListsIdToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingListId",
                table: "Recipes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingListId",
                table: "IngredientListItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ShoppingListId",
                table: "Recipes",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientListItems_ShoppingListId",
                table: "IngredientListItems",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItems_ShoppingLists_ShoppingListId",
                table: "IngredientListItems",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_ShoppingLists_ShoppingListId",
                table: "Recipes",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItems_ShoppingLists_ShoppingListId",
                table: "IngredientListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_ShoppingLists_ShoppingListId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ShoppingListId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_IngredientListItems_ShoppingListId",
                table: "IngredientListItems");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "IngredientListItems");
        }
    }
}
