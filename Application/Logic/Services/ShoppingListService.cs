using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Logic.Services
{
    public class ShoppingListService : IShoppingListService
    {   
        private readonly IBaseRepositoryService<ShoppingList> _baseRepositoryService;
        private readonly IRecipeService _recipeService;
        private readonly DataContext _context;
        private readonly IIngredientListItemService _ingredientListItemService;

        public ShoppingListService(IBaseRepositoryService<ShoppingList> baseRepositoryService, 
        IRecipeService recipeService,
        IIngredientListItemService ingredientListItemService,
        DataContext context)
        {
            _baseRepositoryService = baseRepositoryService;
            _recipeService = recipeService;
            _ingredientListItemService = ingredientListItemService;
            _context = context;
        }

        public async Task<List<Recipe>> GetShoppingListRecipes(Guid shoppingListId)
        {
            var shoppingList = await _baseRepositoryService.GetDetails(shoppingListId);
            var recipes = await _recipeService.QueryRecipes()
                .Where(r => r.ShoppingLists.Contains(shoppingList))
                .ToListAsync();

            return recipes;
        }

        public async Task<List<IngredientListItem>> GetShoppingListIngredientListItems(Guid shoppingListId)
        {
            var shoppingList = await _baseRepositoryService.GetDetails(shoppingListId);
            var ingredientItems = await _ingredientListItemService.QueryIngredientListItems()
                .Where(li => li.ShoppingLists.Contains(shoppingList))
                .ToListAsync();
            return ingredientItems;
        }
        
        public async Task AddRecipeToShoppingList(Guid shoppingListId, Guid recipeId)
        {
            var shoppingList = await _baseRepositoryService.GetDetails(shoppingListId);
            var recipe = await _recipeService.GetRecipeDetails(recipeId);
            bool isDuplicate = await CheckForDuplicateRecipes(shoppingList, recipeId);

            if(recipe is not null && isDuplicate == false){
                shoppingList.Recipes.Add(recipe);
                PopulateRecipeIngredientsToShoppingList(recipe, shoppingList);
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<ShoppingList> QueryShoppingLists()
        {
            return _baseRepositoryService.GetAll();
        }

        public async Task<ShoppingList> GetShoppingListDetails(Guid id)
        {
            return await _baseRepositoryService.GetDetails(id);
        }

        public async Task CreateShoppingList(ShoppingList shoppingList)
        {
            await _baseRepositoryService.Create(shoppingList);
        }

        public async Task EditShoppingList(Guid id, ShoppingList shoppingList)
        {
            await _baseRepositoryService.Edit(id, shoppingList);
        }

        public async Task DeleteShoppingList(Guid id)
        {
            await _baseRepositoryService.Delete(id);
        }

        private async void PopulateRecipeIngredientsToShoppingList(Recipe recipe, ShoppingList shoppingList){
            var recipeIngredientItems = await _ingredientListItemService.ListIngredientListItemByRecipe(recipe.RecipeId);
            if(recipeIngredientItems.Count > 0){
                foreach(var item in recipe.IngredientListItems){
                    if(shoppingList.IngredientListItems.Contains(item))
                    {
                        var existingItem = shoppingList.IngredientListItems.SingleOrDefault(li => li.IngredientListItemId == item.IngredientListItemId);
                        existingItem.Quantity = existingItem.Quantity + item.Quantity;
                    }
                    else
                    {
                        shoppingList.IngredientListItems.Add(item);
                    }
                }
            }
        }

        private async Task<bool> CheckForDuplicateRecipes(ShoppingList shoppingList, Guid recipeId){
            var duplicate = await _recipeService.QueryRecipes()
                .Where(r => r.ShoppingLists.Contains(shoppingList))
                .SingleOrDefaultAsync(r => r.RecipeId == recipeId);
            return duplicate is null ? false : true;
        }
    }
}