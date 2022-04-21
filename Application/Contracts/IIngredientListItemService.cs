using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Contracts
{
    public interface IIngredientListItemService
    {
        IQueryable<IngredientListItem> QueryIngredientListItems();
        
        Task<List<IngredientListItem>> ListIngredientListItemByRecipe(Guid recipeId);

        Task<IngredientListItem> GetIngredientListItemDetails(Guid id);

        Task CreateIngredientListItem(IngredientListItem ingredientListItem);

        Task CreateBulk(List<IngredientListItem> ingredientListItems);

        Task EditIngredientListItem(IngredientListItem editedItem, IngredientListItem ingredientListItem);

        Task DeleteIngredientListItem(Guid id);          
    }
}