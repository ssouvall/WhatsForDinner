using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Recipes;

namespace API.Controllers
{
    public class RecipesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetRecipes()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRecipe(Recipe recipe){
            return Ok(await Mediator.Send(new Create.Command {Recipe = recipe}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(int id, Recipe recipe)
        {
            recipe.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Recipe = recipe}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}