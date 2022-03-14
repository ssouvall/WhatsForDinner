using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class IngredientListItem
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string QuantityUnit { get; set; }
        public string Notes { get; set; }
        public bool isComplete { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}