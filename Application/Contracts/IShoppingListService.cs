using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Contracts
{
    public interface IShoppingListService
    {
        Task AddRecipeToShoppingList(Guid shoppingListId, Guid recipeId);

        Task<List<Recipe>> GetShoppingListRecipes(Guid shoppingListId);

        Task<List<IngredientListItem>> GetShoppingListIngredientListItems(Guid shoppingListId);

        IQueryable<ShoppingList> QueryShoppingLists();

        Task<ShoppingList> GetShoppingListDetails(Guid id);

        Task CreateShoppingList(ShoppingList shoppingList);

        Task EditShoppingList(Guid id, ShoppingList shoppingList);

        Task DeleteShoppingList(Guid id);
    }
}