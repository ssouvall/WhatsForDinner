using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.Recipes = new HashSet<Recipe>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        
         #nullable enable
        public string? QuantityUnit { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}