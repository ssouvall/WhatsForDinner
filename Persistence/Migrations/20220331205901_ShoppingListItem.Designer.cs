﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220331205901_ShoppingListItem")]
    partial class ShoppingListItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Domain.Ingredient", b =>
                {
                    b.Property<Guid>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Domain.IngredientListItem", b =>
                {
                    b.Property<Guid>("IngredientListItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<string>("QuantityUnit")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("TEXT");

                    b.HasKey("IngredientListItemId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("IngredientListItems");
                });

            modelBuilder.Entity("Domain.Recipe", b =>
                {
                    b.Property<Guid>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Instructions")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Domain.ShoppingList", b =>
                {
                    b.Property<Guid>("ShoppingListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ShoppingListId");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("IngredientListItemShoppingList", b =>
                {
                    b.Property<Guid>("IngredientListItemsIngredientListItemId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ShoppingListsShoppingListId")
                        .HasColumnType("TEXT");

                    b.HasKey("IngredientListItemsIngredientListItemId", "ShoppingListsShoppingListId");

                    b.HasIndex("ShoppingListsShoppingListId");

                    b.ToTable("IngredientListItemShoppingList");
                });

            modelBuilder.Entity("RecipeShoppingList", b =>
                {
                    b.Property<Guid>("RecipesRecipeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ShoppingListsShoppingListId")
                        .HasColumnType("TEXT");

                    b.HasKey("RecipesRecipeId", "ShoppingListsShoppingListId");

                    b.HasIndex("ShoppingListsShoppingListId");

                    b.ToTable("RecipeShoppingList");
                });

            modelBuilder.Entity("Domain.IngredientListItem", b =>
                {
                    b.HasOne("Domain.Ingredient", "Ingredient")
                        .WithMany("IngredientListItems")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Recipe", "Recipe")
                        .WithMany("IngredientListItems")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("IngredientListItemShoppingList", b =>
                {
                    b.HasOne("Domain.IngredientListItem", null)
                        .WithMany()
                        .HasForeignKey("IngredientListItemsIngredientListItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ShoppingList", null)
                        .WithMany()
                        .HasForeignKey("ShoppingListsShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeShoppingList", b =>
                {
                    b.HasOne("Domain.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ShoppingList", null)
                        .WithMany()
                        .HasForeignKey("ShoppingListsShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Ingredient", b =>
                {
                    b.Navigation("IngredientListItems");
                });

            modelBuilder.Entity("Domain.Recipe", b =>
                {
                    b.Navigation("IngredientListItems");
                });
#pragma warning restore 612, 618
        }
    }
}
