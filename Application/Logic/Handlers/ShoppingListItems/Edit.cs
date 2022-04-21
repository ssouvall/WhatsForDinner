using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using MediatR;

namespace Application.Logic.Handlers.ShoppingListItems
{
    public class Edit
    {
        public class Command : IRequest
        {
            public ShoppingListItem ShoppingListItem { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IShoppingListItemService _shoppingListItemService;
            public Handler(IShoppingListItemService shoppingListItemService)
            {
                _shoppingListItemService = shoppingListItemService;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var shoppingListItem = await _shoppingListItemService.GetShoppingListItemDetails(request.ShoppingListItem.ShoppingListItemId);
                await _shoppingListItemService.EditShoppingListItem(request.ShoppingListItem, shoppingListItem);
                return Unit.Value;
            }
        }
    }
}