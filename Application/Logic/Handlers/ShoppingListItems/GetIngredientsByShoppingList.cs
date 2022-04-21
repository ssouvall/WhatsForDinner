using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using MediatR;

namespace Application.Logic.Handlers.ShoppingLists
{
    public class GetIngredientsByShoppingList
    {
        public class Query : IRequest<List<ShoppingListItem>>
        {
            public Guid ShoppingListId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<ShoppingListItem>>
        {
            private readonly IShoppingListItemService _shoppingListItemService;
            public Handler(IShoppingListItemService shoppingListItemService)
            {
                _shoppingListItemService = shoppingListItemService;
            }

            public async Task<List<ShoppingListItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _shoppingListItemService.GetIngredientsByShoppingList(request.ShoppingListId);
            }
        }
    }
}