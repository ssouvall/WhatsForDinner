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
        public async Task AddIngredientToRecipe(Guid recipeId, Guid ingredientId)
        {
            Recipe recipe = await _context.Recipes.SingleOrDefaultAsync(r => r.Id == recipeId); 
            Ingredient ingredient = await _context.Ingredients.SingleOrDefaultAsync(ing => ing.Id == ingredientId);
            
            if(recipe is not null && ingredient is not null)
            {
                recipe.Ingredients.Add(ingredient);
                await _context.SaveChangesAsync();
            }
        }
    }
}