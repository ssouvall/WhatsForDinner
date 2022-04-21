using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Contracts
{
    public interface IIngredientService
    {
        IQueryable<Ingredient> QueryIngredients();

        Task<Ingredient> GetIngredientDetails(Guid id);

        Task CreateIngredient(Ingredient ingredient);

        Task EditIngredient(Ingredient editedItem, Ingredient ingredient);

        Task DeleteIngredient(Guid id);        
    }
}