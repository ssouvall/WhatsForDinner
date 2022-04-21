using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Contracts
{
    public interface IRecipeService
    {
        IQueryable<Recipe> QueryRecipes();

        Task<Recipe> GetRecipeDetails(Guid id);

        Task CreateRecipe(Recipe Recipe);

        Task EditRecipe(Recipe editedRecipe, Recipe Recipe);

        Task DeleteRecipe(Guid id);
    }
}