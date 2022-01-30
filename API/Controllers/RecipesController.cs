using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Recipes;
using Application;

namespace API.Controllers
{
    public class RecipesController : BaseApiController
    {
        private readonly IIngredientService _ingredientService;
        public RecipesController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetRecipes()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRecipe(Recipe recipe){
            return Ok(await Mediator.Send(new Create.Command {Recipe = recipe}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditRecipe(Guid id, Recipe recipe)
        {
            recipe.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Recipe = recipe}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }

        [HttpPost("{recipeId}/{ingredientId}")]
        public async Task AddIngredientToRecipe(Guid recipeId, Guid ingredientId)
        {
            await _ingredientService.AddIngredientToRecipe(recipeId, ingredientId);
        }
    }
}