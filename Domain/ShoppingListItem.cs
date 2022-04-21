using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums.Ingredients;

namespace Domain
{
    public class ShoppingListItem
    {
        public Guid ShoppingListItemId { get; set; }
        public Guid IngredientId { get; set; }
        public Guid ShoppingListId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string QuantityUnit { get; set; }
        public string Notes { get; set; }
        public IngredientCategory Category { get; set; }
        public bool isComplete { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual ShoppingList ShoppingList { get; set; }
    }
}