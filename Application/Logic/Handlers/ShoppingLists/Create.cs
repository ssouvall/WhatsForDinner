using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.ShoppingLists
{
    public class Create
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
                await _shoppingListService.CreateShoppingList(request.ShoppingList);
                return Unit.Value;
            }
        }
        
    }
}