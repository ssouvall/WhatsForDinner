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
    public class GetShoppingListIngredientListItems
    {
        public class Query : IRequest<List<IngredientListItem>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<IngredientListItem>>
        {
            private readonly IShoppingListService _shoppingListService;
            public Handler(IShoppingListService shoppingListService)
            {
                _shoppingListService = shoppingListService;
            }

            public async Task<List<IngredientListItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _shoppingListService.GetShoppingListIngredientListItems(request.Id);
            }
        }
    }
}