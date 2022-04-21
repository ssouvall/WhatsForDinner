using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Logic.Services
{
    public class IngredientListItemService : IIngredientListItemService
    {
        private readonly IBaseRepositoryService<IngredientListItem> _baseRepositoryService;
        public IngredientListItemService(IBaseRepositoryService<IngredientListItem> baseRepositoryService){
            _baseRepositoryService = baseRepositoryService;
        }

        public async Task CreateBulk(List<IngredientListItem> ingredientListItems)
        {
            if(ingredientListItems.Count > 0)
            {
                foreach(var item in ingredientListItems)
                {
                    await _baseRepositoryService.Create(item);
                }
            }
        }

        public async Task CreateIngredientListItem(IngredientListItem ingredientListItem)
        {
            await _baseRepositoryService.Create(ingredientListItem);
        }

        public async Task DeleteIngredientListItem(Guid id)
        {
            await _baseRepositoryService.Delete(id);
        }

        public async Task EditIngredientListItem(IngredientListItem editedItem, IngredientListItem ingredientListItem)
        {
            await _baseRepositoryService.Edit(editedItem, ingredientListItem);
        }

        public async Task<IngredientListItem> GetIngredientListItemDetails(Guid id)
        {
            return await _baseRepositoryService.GetDetails(id);
        }

        public async Task<List<IngredientListItem>> ListIngredientListItemByRecipe(Guid recipeId)
        {
            return await _baseRepositoryService.GetAll()
                .Where(ili => ili.RecipeId == recipeId)
                .ToListAsync();
        }

        public IQueryable<IngredientListItem> QueryIngredientListItems()
        {
            return _baseRepositoryService.GetAll();
        }
    }
}