using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Contracts
{
    public interface IRecipeService
    {
        Task<List<Recipe>> ListRecipes();

        Task<Recipe> GetRecipeDetails(Guid id);

        Task CreateRecipe(Recipe Recipe);

        Task EditRecipe(Guid id, Recipe Recipe);

        Task DeleteRecipe(Guid id);
    }
}