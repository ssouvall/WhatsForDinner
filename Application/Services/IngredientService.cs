using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly DataContext _context;
        public IngredientService(DataContext context)
        {
            _context = context;
        }
        public async Task AddIngredientItemToRecipe(Guid recipeId, Guid ingredientId, int quantity, string quantityUnit, string notes)
        {
            Recipe recipe = await _context.Recipes.SingleOrDefaultAsync(r => r.Id == recipeId); 
            Ingredient ingredient = await _context.Ingredients.SingleOrDefaultAsync(ing => ing.Id == ingredientId);
            
            if(recipe is not null && ingredient is not null)
            {
                var newItem = new IngredientListItem{
                    RecipeId = recipeId,
                    Ingredient = ingredient,
                    Quantity = quantity,
                    QuantityUnit = quantityUnit,
                    Notes = notes,
                    isComplete = false
                };
                recipe.IngredientListItems.Add(newItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}