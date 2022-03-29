using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;

namespace Application.Logic.Services
{
    public class ShoppingListService : IShoppingListService
    {   
        private readonly IBaseRepositoryService<ShoppingList> _baseRepositoryService;
        public ShoppingListService(IBaseRepositoryService<ShoppingList> baseRepositoryService){
            _baseRepositoryService = baseRepositoryService;
        }

        public Task<List<Recipe>> GetShoppingListRecipes(Guid shoppingListId)
        {
            throw new NotImplementedException();
        }
        
        public Task AddRecipeToShoppingList(Guid shoppingListId, Guid recipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ShoppingList>> ListShoppingLists()
        {
            return await _baseRepositoryService.List();
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
    }
}