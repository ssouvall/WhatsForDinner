using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.ShoppingListItems
{
    public class CreateBulk
    {
        public class Command : IRequest
        {
            public List<ShoppingListItem> ShoppingListItems { get; set; }
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
                await _shoppingListItemService.CreateBulk(request.ShoppingListItems);
                return Unit.Value;
            }
        }
        
    }
}