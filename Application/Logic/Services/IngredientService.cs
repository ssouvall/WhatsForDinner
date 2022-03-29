using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Logic.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IBaseRepositoryService<Ingredient> _baseRepositoryService;
        public IngredientService(IBaseRepositoryService<Ingredient> baseRepositoryService){
            _baseRepositoryService = baseRepositoryService;
        }

        public async Task CreateIngredient(Ingredient ingredient)
        {
            await _baseRepositoryService.Create(ingredient);
        }

        public async Task DeleteIngredient(Guid id)
        {
            await _baseRepositoryService.Delete(id);
        }

        public async Task EditIngredient(Guid id, Ingredient ingredient)
        {
            await _baseRepositoryService.Edit(id, ingredient);
        }

        public async Task<Ingredient> GetIngredientDetails(Guid id)
        {
            return await _baseRepositoryService.GetDetails(id);
        }

        public async Task<List<Ingredient>> ListIngredients()
        {
            return await _baseRepositoryService.GetAll().ToListAsync();
        }
    }
}