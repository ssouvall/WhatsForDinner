using System;
using System.Collections.Generic;

namespace Domain
{
    public class IngredientListItem
    {
        public IngredientListItem() {
            this.ShoppingLists = new HashSet<ShoppingList>();
        }

        public Guid Id { get; set; }
        public Guid? RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string QuantityUnit { get; set; }
        public string Notes { get; set; }
        public bool isComplete { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}