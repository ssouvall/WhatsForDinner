using System;
using System.Collections.Generic;

namespace Domain
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        
        public virtual ICollection<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();

    }
}
