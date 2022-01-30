using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public interface IIngredientService
    {
        Task AddIngredientToRecipe(Guid recipeId, Guid ingredientId);
    }
}