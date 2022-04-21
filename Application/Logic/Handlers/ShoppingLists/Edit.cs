using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.ShoppingLists
{
    public class Edit
    {
        public class Command : IRequest
        {
            public ShoppingList ShoppingList { get; set; }
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
                var shoppingList = await _shoppingListService.GetShoppingListDetails(request.ShoppingList.ShoppingListId);
                await _shoppingListService.EditShoppingList(request.ShoppingList, shoppingList);
                return Unit.Value;
            }
        }
    }
}