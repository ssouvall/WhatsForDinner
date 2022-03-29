using System;
using System.Collections.Generic;

namespace Domain
{
    public class Recipe
    {
        public Recipe () {
            this.ShoppingLists = new HashSet<ShoppingList>();
            this.IngredientListItems = new HashSet<IngredientListItem>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
        public virtual ICollection<IngredientListItem> IngredientListItems { get; set; } 
    }
}
