using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedRecipeData(DataContext context)
        {
            if (context.Recipes.Any()) return;
            
            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    Name = "Recipe One",
                    Category = "Italian",
                    Description = "Description One",
                    Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a risus a enim ornare vulputate. In faucibus odio vitae elit congue dignissim. Nullam et arcu sit amet felis varius pulvinar. Pellentesque rutrum ligula id justo maximus eleifend. Aenean vulputate quis nunc quis varius. Aliquam bibendum augue urna, sed volutpat diam tempor et. Nulla commodo non tellus in malesuada. Phasellus eget sapien erat."
                },
                new Recipe
                {
                    Name = "Recipe Two",
                    Category = "Italian",
                    Description = "Description Two",
                    Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a risus a enim ornare vulputate. In faucibus odio vitae elit congue dignissim. Nullam et arcu sit amet felis varius pulvinar. Pellentesque rutrum ligula id justo maximus eleifend. Aenean vulputate quis nunc quis varius. Aliquam bibendum augue urna, sed volutpat diam tempor et. Nulla commodo non tellus in malesuada. Phasellus eget sapien erat."
                },
                new Recipe
                {
                    Name = "Recipe Three",
                    Category = "Vegetarian",
                    Description = "Description Three",
                    Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a risus a enim ornare vulputate. In faucibus odio vitae elit congue dignissim. Nullam et arcu sit amet felis varius pulvinar. Pellentesque rutrum ligula id justo maximus eleifend. Aenean vulputate quis nunc quis varius. Aliquam bibendum augue urna, sed volutpat diam tempor et. Nulla commodo non tellus in malesuada. Phasellus eget sapien erat."
                },
                new Recipe
                {
                    Name = "Recipe Four",
                    Category = "Indian",
                    Description = "Description Four",
                    Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a risus a enim ornare vulputate. In faucibus odio vitae elit congue dignissim. Nullam et arcu sit amet felis varius pulvinar. Pellentesque rutrum ligula id justo maximus eleifend. Aenean vulputate quis nunc quis varius. Aliquam bibendum augue urna, sed volutpat diam tempor et. Nulla commodo non tellus in malesuada. Phasellus eget sapien erat."
                },
                new Recipe
                {
                    Name = "Recipe Five",
                    Category = "Indian",
                    Description = "Description Five",
                    Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a risus a enim ornare vulputate. In faucibus odio vitae elit congue dignissim. Nullam et arcu sit amet felis varius pulvinar. Pellentesque rutrum ligula id justo maximus eleifend. Aenean vulputate quis nunc quis varius. Aliquam bibendum augue urna, sed volutpat diam tempor et. Nulla commodo non tellus in malesuada. Phasellus eget sapien erat."
                },
                new Recipe
                {
                    Name = "Recipe Six",
                    Category = "Indian",
                    Description = "Description Six",
                    Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a risus a enim ornare vulputate. In faucibus odio vitae elit congue dignissim. Nullam et arcu sit amet felis varius pulvinar. Pellentesque rutrum ligula id justo maximus eleifend. Aenean vulputate quis nunc quis varius. Aliquam bibendum augue urna, sed volutpat diam tempor et. Nulla commodo non tellus in malesuada. Phasellus eget sapien erat."
                },
                new Recipe
                {
                    Name = "Recipe Seven",
                    Category = "Indian",
                    Description = "Description Seven",
                    Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a risus a enim ornare vulputate. In faucibus odio vitae elit congue dignissim. Nullam et arcu sit amet felis varius pulvinar. Pellentesque rutrum ligula id justo maximus eleifend. Aenean vulputate quis nunc quis varius. Aliquam bibendum augue urna, sed volutpat diam tempor et. Nulla commodo non tellus in malesuada. Phasellus eget sapien erat."
                },
                new Recipe
                {
                    Name = "Recipe Eight",
                    Category = "Easy Dinners",
                    Description = "Description Eight",
                    Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a risus a enim ornare vulputate. In faucibus odio vitae elit congue dignissim. Nullam et arcu sit amet felis varius pulvinar. Pellentesque rutrum ligula id justo maximus eleifend. Aenean vulputate quis nunc quis varius. Aliquam bibendum augue urna, sed volutpat diam tempor et. Nulla commodo non tellus in malesuada. Phasellus eget sapien erat."
                },
                new Recipe
                {
                    Name = "Recipe Nine",
                    Category = "Easy Dinners",
                    Description = "Description Nine",
                    Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a risus a enim ornare vulputate. In faucibus odio vitae elit congue dignissim. Nullam et arcu sit amet felis varius pulvinar. Pellentesque rutrum ligula id justo maximus eleifend. Aenean vulputate quis nunc quis varius. Aliquam bibendum augue urna, sed volutpat diam tempor et. Nulla commodo non tellus in malesuada. Phasellus eget sapien erat."
                },
                new Recipe
                {
                    Name = "Recipe Ten",
                    Category = "Easy Dinners",
                    Description = "Description Ten",
                    Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a risus a enim ornare vulputate. In faucibus odio vitae elit congue dignissim. Nullam et arcu sit amet felis varius pulvinar. Pellentesque rutrum ligula id justo maximus eleifend. Aenean vulputate quis nunc quis varius. Aliquam bibendum augue urna, sed volutpat diam tempor et. Nulla commodo non tellus in malesuada. Phasellus eget sapien erat."
                }
            };
            
            await context.Recipes.AddRangeAsync(recipes);
            await context.SaveChangesAsync();
        }

        public static async Task SeedIngredientData(DataContext context)
        {
            if (context.Ingredients.Any()) return;
            
            var ingredients = new List<Ingredient>
            {
                new Ingredient
                {
                    Name = "Ingredient One",
                    Quantity = 2.0,
                    QuantityUnit = "Cups",
                    RecipeId = 1,
                },
                new Ingredient
                {
                    Name = "Ingredient Two",
                    Quantity = 5.0,
                    QuantityUnit = "Tablespoons",
                    RecipeId = 1,
                },
                new Ingredient
                {
                    Name = "Ingredient Three",
                    Quantity = 1.0,
                    QuantityUnit = "Quart",
                    RecipeId = 1,
                },
                new Ingredient
                {
                    Name = "Ingredient Four",
                    Quantity = 3.0,
                    QuantityUnit = "Cups",
                    RecipeId = 2,
                },
                new Ingredient
                {
                    Name = "Ingredient Five",
                    Quantity = 1.0,
                    QuantityUnit = "Pound",
                    RecipeId = 2,
                },
                new Ingredient
                {
                    Name = "Ingredient Six",
                    Quantity = 2.0,
                    QuantityUnit = "Bags",
                    RecipeId = 2,
                },
                new Ingredient
                {
                    Name = "Ingredient Seven",
                    Quantity = 8.0,
                    QuantityUnit = "Ounces",
                    RecipeId = 3,
                },
                new Ingredient
                {
                    Name = "Ingredient Eight",
                    Quantity = 2.0,
                    QuantityUnit = "Tablespoons",
                    RecipeId = 3,
                },
                new Ingredient
                {
                    Name = "Ingredient Nine",
                    Quantity = 0.5,
                    QuantityUnit = "Can",
                    RecipeId = 3
                },
                new Ingredient
                {
                    Name = "Ingredient Ten",
                    Quantity = 2.0,
                    QuantityUnit = "Cups",
                    RecipeId = 4,
                }
            };
            
            await context.Ingredients.AddRangeAsync(ingredients);
            await context.SaveChangesAsync();
        }
    }
}