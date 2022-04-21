using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class ShoppingList
    {
        public ShoppingList() 
        {
            this.Recipes = new HashSet<Recipe>();
            this.IngredientListItems = new HashSet<IngredientListItem>();
            this.ShoppingListItems = new HashSet<ShoppingListItem>();
        }
        public Guid ShoppingListId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<IngredientListItem> IngredientListItems { get; set; }
        public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}