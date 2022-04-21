using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Logic.Handlers.ShoppingListItems;
using Application;

namespace API.Controllers
{
    public class ShoppingListItemsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<ShoppingListItem>>> GetShoppingListItems()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingListItem>> GetShoppingListItem(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateShoppingListItem(ShoppingListItem shoppingListItem)
        {
            return Ok(await Mediator.Send(new Create.Command {ShoppingListItem = shoppingListItem}));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateShoppingListItemBulk(List<ShoppingListItem> shoppingListItems){
            return Ok(await Mediator.Send(new CreateBulk.Command {ShoppingListItems = shoppingListItems}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditShoppingListItem(Guid id, ShoppingListItem shoppingListItem)
        {
            shoppingListItem.ShoppingListItemId = id;
            return Ok(await Mediator.Send(new Edit.Command{ShoppingListItem = shoppingListItem}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingListItem(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}