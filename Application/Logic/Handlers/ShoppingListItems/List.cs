using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Logic.Handlers.ShoppingListItems
{
    public class List
    {
        public class Query : IRequest<List<ShoppingListItem>> { }
        public class Handler : IRequestHandler<Query, List<ShoppingListItem>>
        {
            private readonly IShoppingListItemService _shoppingListItemService;
            public Handler(IShoppingListItemService shoppingListItemService)
            {
                _shoppingListItemService = shoppingListItemService;
            }

            public async Task<List<ShoppingListItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _shoppingListItemService.QueryShoppingListItems().ToListAsync();
            }
        }
    }
}