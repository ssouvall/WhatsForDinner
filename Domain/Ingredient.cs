using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums.Ingredients;

namespace Domain
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.IngredientListItems = new HashSet<IngredientListItem>();
            this.ShoppingListItems = new HashSet<ShoppingListItem>();
        }

        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public IngredientCategory Category { get; set; }
        public virtual ICollection<IngredientListItem> IngredientListItems { get; set; }
        public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}