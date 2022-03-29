using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Logic.Handlers.Ingredients;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class IngredientsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Ingredient>>> GetIngredients()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredient(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateIngredient(Ingredient ingredient){
            return Ok(await Mediator.Send(new Create.Command {Ingredient = ingredient}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditIngredient(Guid id, Ingredient ingredient)
        {
            ingredient.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Ingredient = ingredient}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}