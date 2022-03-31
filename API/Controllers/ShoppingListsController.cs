using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Logic.Handlers.ShoppingLists;
using Application;

namespace API.Controllers
{
    public class ShoppingListsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<ShoppingList>>> GetShoppingLists()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingList>> GetShoppingList(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateShoppingList(ShoppingList shoppingList)
        {
            return Ok(await Mediator.Send(new Create.Command {ShoppingList = shoppingList}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditShoppingList(Guid id, ShoppingList shoppingList)
        {
            shoppingList.ShoppingListId = id;
            return Ok(await Mediator.Send(new Edit.Command{ShoppingList = shoppingList}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingList(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<List<Recipe>>> GetShoppingListRecipes(Guid id)
        {
            return await Mediator.Send(new GetShoppingListRecipes.Query{Id = id});
        }

        [HttpPost("[action]/{id}/{recipeId}")]
        public async Task<IActionResult> AddRecipeToShoppingList(Guid id, Guid recipeId)
        {
            return Ok(await Mediator.Send(new AddRecipeToShoppingList.Command {Id = id, RecipeId = recipeId}));
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<List<IngredientListItem>>> GetShoppingListIngredientListItems(Guid id)
        {
            return await Mediator.Send(new GetShoppingListIngredientListItems.Query{Id = id});
        }
    }
}