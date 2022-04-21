using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ShoppingListItemFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingListItems",
                columns: table => new
                {
                    ShoppingListItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IngredientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShoppingListId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    isComplete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItems", x => x.ShoppingListItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingListItems_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListItems_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "ShoppingListId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_IngredientId",
                table: "ShoppingListItems",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ShoppingListId",
                table: "ShoppingListItems",
                column: "ShoppingListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeShoppingListItem");

            migrationBuilder.DropTable(
                name: "ShoppingListItems");
        }
    }
}
