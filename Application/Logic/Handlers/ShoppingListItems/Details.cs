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
    public class Details
    {
        public class Query : IRequest<ShoppingListItem>
        {
            public Guid Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, ShoppingListItem>
        {
            private readonly IShoppingListItemService _shoppingListItemService;
            public Handler(IShoppingListItemService shoppingListItemService)
            {
                _shoppingListItemService = shoppingListItemService;
            }

            public async Task<ShoppingListItem> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _shoppingListItemService.GetShoppingListItemDetails(request.Id); 
            }
        }
    }
}