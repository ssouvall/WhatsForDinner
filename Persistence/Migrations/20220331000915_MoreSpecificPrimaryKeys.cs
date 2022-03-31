using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class MoreSpecificPrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItemShoppingList_IngredientListItems_IngredientListItemsId",
                table: "IngredientListItemShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItemShoppingList_ShoppingLists_ShoppingListsId",
                table: "IngredientListItemShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeShoppingList_Recipes_RecipesId",
                table: "RecipeShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeShoppingList_ShoppingLists_ShoppingListsId",
                table: "RecipeShoppingList");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingLists",
                newName: "ShoppingListId");

            migrationBuilder.RenameColumn(
                name: "ShoppingListsId",
                table: "RecipeShoppingList",
                newName: "ShoppingListsShoppingListId");

            migrationBuilder.RenameColumn(
                name: "RecipesId",
                table: "RecipeShoppingList",
                newName: "RecipesRecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeShoppingList_ShoppingListsId",
                table: "RecipeShoppingList",
                newName: "IX_RecipeShoppingList_ShoppingListsShoppingListId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Recipes",
                newName: "RecipeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ingredients",
                newName: "IngredientId");

            migrationBuilder.RenameColumn(
                name: "ShoppingListsId",
                table: "IngredientListItemShoppingList",
                newName: "ShoppingListsShoppingListId");

            migrationBuilder.RenameColumn(
                name: "IngredientListItemsId",
                table: "IngredientListItemShoppingList",
                newName: "IngredientListItemsIngredientListItemId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientListItemShoppingList_ShoppingListsId",
                table: "IngredientListItemShoppingList",
                newName: "IX_IngredientListItemShoppingList_ShoppingListsShoppingListId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "IngredientListItems",
                newName: "IngredientListItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItemShoppingList_IngredientListItems_IngredientListItemsIngredientListItemId",
                table: "IngredientListItemShoppingList",
                column: "IngredientListItemsIngredientListItemId",
                principalTable: "IngredientListItems",
                principalColumn: "IngredientListItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItemShoppingList_ShoppingLists_ShoppingListsShoppingListId",
                table: "IngredientListItemShoppingList",
                column: "ShoppingListsShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "ShoppingListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeShoppingList_Recipes_RecipesRecipeId",
                table: "RecipeShoppingList",
                column: "RecipesRecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeShoppingList_ShoppingLists_ShoppingListsShoppingListId",
                table: "RecipeShoppingList",
                column: "ShoppingListsShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "ShoppingListId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItemShoppingList_IngredientListItems_IngredientListItemsIngredientListItemId",
                table: "IngredientListItemShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItemShoppingList_ShoppingLists_ShoppingListsShoppingListId",
                table: "IngredientListItemShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeShoppingList_Recipes_RecipesRecipeId",
                table: "RecipeShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeShoppingList_ShoppingLists_ShoppingListsShoppingListId",
                table: "RecipeShoppingList");

            migrationBuilder.RenameColumn(
                name: "ShoppingListId",
                table: "ShoppingLists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ShoppingListsShoppingListId",
                table: "RecipeShoppingList",
                newName: "ShoppingListsId");

            migrationBuilder.RenameColumn(
                name: "RecipesRecipeId",
                table: "RecipeShoppingList",
                newName: "RecipesId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeShoppingList_ShoppingListsShoppingListId",
                table: "RecipeShoppingList",
                newName: "IX_RecipeShoppingList_ShoppingListsId");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Recipes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "Ingredients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ShoppingListsShoppingListId",
                table: "IngredientListItemShoppingList",
                newName: "ShoppingListsId");

            migrationBuilder.RenameColumn(
                name: "IngredientListItemsIngredientListItemId",
                table: "IngredientListItemShoppingList",
                newName: "IngredientListItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientListItemShoppingList_ShoppingListsShoppingListId",
                table: "IngredientListItemShoppingList",
                newName: "IX_IngredientListItemShoppingList_ShoppingListsId");

            migrationBuilder.RenameColumn(
                name: "IngredientListItemId",
                table: "IngredientListItems",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItemShoppingList_IngredientListItems_IngredientListItemsId",
                table: "IngredientListItemShoppingList",
                column: "IngredientListItemsId",
                principalTable: "IngredientListItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItemShoppingList_ShoppingLists_ShoppingListsId",
                table: "IngredientListItemShoppingList",
                column: "ShoppingListsId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeShoppingList_Recipes_RecipesId",
                table: "RecipeShoppingList",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeShoppingList_ShoppingLists_ShoppingListsId",
                table: "RecipeShoppingList",
                column: "ShoppingListsId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
