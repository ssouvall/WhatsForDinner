using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string QuantityUnit { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}