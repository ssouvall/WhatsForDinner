using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Contracts
{
    public interface IShoppingListItemService
    {
        IQueryable<ShoppingListItem> QueryShoppingListItems();

        Task<ShoppingListItem> GetShoppingListItemDetails(Guid id);

        Task CreateShoppingListItem(ShoppingListItem shoppingListItem);

        Task CreateBulk(List<ShoppingListItem> shoppingListItems);

        Task EditShoppingListItem(ShoppingListItem editedItem, ShoppingListItem shoppingListItem);

        Task DeleteShoppingListItem(Guid id);  
                
        Task<List<ShoppingListItem>> GetIngredientsByShoppingList(Guid shoppingListId);
    }
}