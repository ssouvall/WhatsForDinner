using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using MediatR;

namespace Application.Logic.Handlers.ShoppingLists
{
    public class AddRecipeToShoppingList
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public Guid RecipeId { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly IShoppingListService _shoppingListService;
            public Handler(IShoppingListService shoppingListService)
            {
                _shoppingListService = shoppingListService;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _shoppingListService.AddRecipeToShoppingList(request.Id, request.RecipeId);
                return Unit.Value;
            }
        }
    }
}