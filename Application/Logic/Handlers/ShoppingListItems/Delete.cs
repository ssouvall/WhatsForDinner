using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.ShoppingListItems
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                await _shoppingListItemService.DeleteShoppingListItem(request.Id);
                return Unit.Value;
            }
        }
    }
}