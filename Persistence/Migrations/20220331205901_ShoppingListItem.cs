using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ShoppingListItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItems_Recipes_RecipeId",
                table: "IngredientListItems");

            migrationBuilder.DropColumn(
                name: "isComplete",
                table: "IngredientListItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "IngredientListItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "IngredientListItems",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItems_Recipes_RecipeId",
                table: "IngredientListItems",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientListItems_Recipes_RecipeId",
                table: "IngredientListItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "IngredientListItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "IngredientListItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AddColumn<bool>(
                name: "isComplete",
                table: "IngredientListItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientListItems_Recipes_RecipeId",
                table: "IngredientListItems",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
