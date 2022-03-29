using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Logic.Handlers.ShoppingLists
{
    public class List
    {
        public class Query : IRequest<List<ShoppingList>> { }
        public class Handler : IRequestHandler<Query, List<ShoppingList>>
        {
            private readonly IShoppingListService _shoppingListService;
            public Handler(IShoppingListService shoppingListService)
            {
                _shoppingListService = shoppingListService;
            }

            public async Task<List<ShoppingList>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _shoppingListService.ListShoppingLists();
            }
        }

    }
}