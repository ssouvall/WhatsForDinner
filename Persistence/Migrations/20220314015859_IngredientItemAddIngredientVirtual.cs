using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class IngredientItemAddIngredientVirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItem_Ingredients_IngredientId",
                table: "IngredientListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItem_Recipes_RecipeId",
                table: "IngredientListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientListItem",
                table: "IngredientListItem");

            migrationBuilder.RenameTable(
                name: "IngredientListItem",
                newName: "IngredientListItems");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientListItem_RecipeId",
                table: "IngredientListItems",
                newName: "IX_IngredientListItems_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientListItem_IngredientId",
                table: "IngredientListItems",
                newName: "IX_IngredientListItems_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientListItems",
                table: "IngredientListItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItems_Ingredients_IngredientId",
                table: "IngredientListItems",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItems_Recipes_RecipeId",
                table: "IngredientListItems",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItems_Ingredients_IngredientId",
                table: "IngredientListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItems_Recipes_RecipeId",
                table: "IngredientListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientListItems",
                table: "IngredientListItems");

            migrationBuilder.RenameTable(
                name: "IngredientListItems",
                newName: "IngredientListItem");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientListItems_RecipeId",
                table: "IngredientListItem",
                newName: "IX_IngredientListItem_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientListItems_IngredientId",
                table: "IngredientListItem",
                newName: "IX_IngredientListItem_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientListItem",
                table: "IngredientListItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItem_Ingredients_IngredientId",
                table: "IngredientListItem",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItem_Recipes_RecipeId",
                table: "IngredientListItem",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
