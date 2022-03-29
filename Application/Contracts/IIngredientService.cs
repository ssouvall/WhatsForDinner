using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Contracts
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> ListIngredients();

        Task<Ingredient> GetIngredientDetails(Guid id);

        Task CreateIngredient(Ingredient ingredient);

        Task EditIngredient(Guid id, Ingredient ingredient);

        Task DeleteIngredient(Guid id);        
    }
}