using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Logic.Handlers.IngredientListItems;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class IngredientListItemsController : BaseApiController
    {
        [HttpGet("[action]/{recipeId}")]
        public async Task<ActionResult<List<IngredientListItem>>> GetIngredientListItemsByRecipe(Guid recipeId)
        {
            return await Mediator.Send(new ListByRecipe.Query{RecipeId = recipeId});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientListItem>> GetIngredientListItem(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateIngredientListItem(IngredientListItem ingredientListItem){
            return Ok(await Mediator.Send(new Create.Command {IngredientListItem = ingredientListItem}));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateIngredientListItemBulk(List<IngredientListItem> ingredientListItems){
            return Ok(await Mediator.Send(new CreateBulk.Command {IngredientListItems = ingredientListItems}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditIngredientListItem(Guid id, IngredientListItem ingredientListItem)
        {
            ingredientListItem.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{IngredientListItem = ingredientListItem}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientListItem(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}