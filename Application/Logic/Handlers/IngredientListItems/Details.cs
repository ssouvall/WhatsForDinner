using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.IngredientListItems
{
    public class Details
    {
        public class Query : IRequest<IngredientListItem>
        {
            public Guid Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, IngredientListItem>
        {
            private readonly IIngredientListItemService _ingredientListItemService;
            public Handler(IIngredientListItemService ingredientListItemService)
            {
                _ingredientListItemService = ingredientListItemService;
            }

            public async Task<IngredientListItem> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _ingredientListItemService.GetIngredientListItemDetails(request.Id); 
            }
        }
    }
}