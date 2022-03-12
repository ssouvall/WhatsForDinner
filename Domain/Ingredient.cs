using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums.Ingredients;

namespace Domain
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IngredientCategory Category { get; set; }
        public virtual ICollection<IngredientListItem> IngredientListItems { get; set; } = new HashSet<IngredientListItem>();
    }
}