using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixCircularDependency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeShoppingListItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeShoppingListItem",
                columns: table => new
                {
                    RecipesRecipeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShoppingListItemsShoppingListItemId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeShoppingListItem", x => new { x.RecipesRecipeId, x.ShoppingListItemsShoppingListItemId });
                    table.ForeignKey(
                        name: "FK_RecipeShoppingListItem_Recipes_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeShoppingListItem_ShoppingListItems_ShoppingListItemsShoppingListItemId",
                        column: x => x.ShoppingListItemsShoppingListItemId,
                        principalTable: "ShoppingListItems",
                        principalColumn: "ShoppingListItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeShoppingListItem_ShoppingListItemsShoppingListItemId",
                table: "RecipeShoppingListItem",
                column: "ShoppingListItemsShoppingListItemId");
        }
    }
}
