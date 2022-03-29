using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RecipeAndShoppingListManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItems_Recipes_RecipeId",
                table: "IngredientListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItems_ShoppingLists_ShoppingListId",
                table: "IngredientListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_ShoppingLists_ShoppingListId",
                table: "Recipes");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "IngredientListItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "IngredientListItemShoppingList",
                columns: table => new
                {
                    IngredientListItemsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShoppingListsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientListItemShoppingList", x => new { x.IngredientListItemsId, x.ShoppingListsId });
                    table.ForeignKey(
                        name: "FK_IngredientListItemShoppingList_IngredientListItems_IngredientListItemsId",
                        column: x => x.IngredientListItemsId,
                        principalTable: "IngredientListItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientListItemShoppingList_ShoppingLists_ShoppingListsId",
                        column: x => x.ShoppingListsId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeShoppingList",
                columns: table => new
                {
                    RecipesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShoppingListsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeShoppingList", x => new { x.RecipesId, x.ShoppingListsId });
                    table.ForeignKey(
                        name: "FK_RecipeShoppingList_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeShoppingList_ShoppingLists_ShoppingListsId",
                        column: x => x.ShoppingListsId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientListItemShoppingList_ShoppingListsId",
                table: "IngredientListItemShoppingList",
                column: "ShoppingListsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeShoppingList_ShoppingListsId",
                table: "RecipeShoppingList",
                column: "ShoppingListsId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItems_Recipes_RecipeId",
                table: "IngredientListItems",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItems_Recipes_RecipeId",
                table: "IngredientListItems");

            migrationBuilder.DropTable(
                name: "IngredientListItemShoppingList");

            migrationBuilder.DropTable(
                name: "RecipeShoppingList");

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingListId",
                table: "Recipes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "IngredientListItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingListId",
                table: "IngredientListItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ShoppingListId",
                table: "Recipes",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientListItems_ShoppingListId",
                table: "IngredientListItems",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItems_Recipes_RecipeId",
                table: "IngredientListItems",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
