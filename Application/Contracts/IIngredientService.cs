using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public interface IIngredientService
    {
        Task AddIngredientItemToRecipe(Guid recipeId, Guid ingredientId, int quantity, string quantityUnit, string notes);
    }
}