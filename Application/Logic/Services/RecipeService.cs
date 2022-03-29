using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Logic.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IBaseRepositoryService<Recipe> _baseRepositoryService;
        public RecipeService(IBaseRepositoryService<Recipe> baseRepositoryService){
            _baseRepositoryService = baseRepositoryService;
        }

        public async Task CreateRecipe(Recipe recipe)
        {
            await _baseRepositoryService.Create(recipe);
        }

        public async Task DeleteRecipe(Guid id)
        {
            await _baseRepositoryService.Delete(id);
        }

        public async Task EditRecipe(Guid id, Recipe recipe)
        {
            await _baseRepositoryService.Edit(id, recipe);
        }

        public async Task<Recipe> GetRecipeDetails(Guid id)
        {
            return await _baseRepositoryService.GetDetails(id);
        }

        public async Task<List<Recipe>> ListRecipes()
        {
            return await _baseRepositoryService.GetAll().ToListAsync();
        }
    }
}