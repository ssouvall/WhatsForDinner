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
        private readonly IIngredientService _ingredientService;
        private readonly DataContext _context;
        private readonly IIngredientListItemService _ingredientListItemService;
        private readonly IShoppingListItemService _shoppingListItemService;

        public ShoppingListService(IBaseRepositoryService<ShoppingList> baseRepositoryService, 
        IRecipeService recipeService,
        IIngredientService ingredientService,
        IIngredientListItemService ingredientListItemService,
        IShoppingListItemService shoppingListItemService,
        DataContext context)
        {
            _baseRepositoryService = baseRepositoryService;
            _recipeService = recipeService;
            _ingredientService = ingredientService;
            _ingredientListItemService = ingredientListItemService;
            _shoppingListItemService = shoppingListItemService;
            _context = context;
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

        public async Task EditShoppingList(ShoppingList editedItem, ShoppingList shoppingList)
        {
            await _baseRepositoryService.Edit(editedItem, shoppingList);
        }

        public async Task DeleteShoppingList(Guid id)
        {
            await _baseRepositoryService.Delete(id);
        }

        public async Task<List<Recipe>> GetShoppingListRecipes(Guid shoppingListId)
        {
            var shoppingList = await _baseRepositoryService.GetDetails(shoppingListId);
            var recipes = await _recipeService.QueryRecipes()
                .Where(r => r.ShoppingLists.Contains(shoppingList))
                .ToListAsync();

            return recipes;
        }
        
        public async Task<bool> AddRecipeToShoppingList(Guid shoppingListId, Guid recipeId)
        {
            var shoppingList = await _baseRepositoryService.GetDetails(shoppingListId);
            var recipe = await _recipeService.GetRecipeDetails(recipeId);
            Recipe duplicate = await CheckForDuplicateRecipes(shoppingList, recipeId);

            if(recipe is not null && duplicate is null){
                shoppingList.Recipes.Add(recipe);
                await PopulateRecipeIngredientsToShoppingList(recipe, shoppingList);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveRecipeFromShoppingList(Guid shoppingListId, Guid recipeId)
        {
            var shoppingList = await _baseRepositoryService.GetDetails(shoppingListId);
            var recipe = await _recipeService.GetRecipeDetails(recipeId);
            
            if(recipe is not null && shoppingList is not null)
            {
                shoppingList.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        private async Task PopulateRecipeIngredientsToShoppingList(Recipe recipe, ShoppingList shoppingList){
            var recipeIngredientItems = await _ingredientListItemService.ListIngredientListItemByRecipe(recipe.RecipeId);
            if(recipeIngredientItems.Count > 0){
                foreach(var item in recipe.IngredientListItems){
                    var ingredient = await _ingredientService.GetIngredientDetails(item.IngredientId);
                    var newShoppingListItem = new ShoppingListItem
                    {
                        IngredientId = item.IngredientId,
                        ShoppingListId = shoppingList.ShoppingListId,
                        Name = item.Name,
                        Quantity = item.Quantity,
                        QuantityUnit = item.QuantityUnit,
                        Notes = item.Notes,
                        Category = ingredient.Category,
                        isComplete = false,
                    };
                    shoppingList.ShoppingListItems.Add(newShoppingListItem);
                }
            }
        }

        private async Task<Recipe> CheckForDuplicateRecipes(ShoppingList shoppingList, Guid recipeId){
            var duplicate = await _recipeService.QueryRecipes()
                .Where(r => r.ShoppingLists.Contains(shoppingList))
                .SingleOrDefaultAsync(r => r.RecipeId == recipeId);
            return duplicate;
        }
    }
}