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

namespace Application.Logic.Handlers.IngredientListItems
{
    public class ListByRecipe
    {
        public class Query : IRequest<List<IngredientListItem>> 
        { 
            public Guid RecipeId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<IngredientListItem>>
        {
            private readonly IIngredientListItemService _ingredientListItemService;
            public Handler(IIngredientListItemService ingredientListItemService)
            {
                _ingredientListItemService = ingredientListItemService;
            }

            public async Task<List<IngredientListItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _ingredientListItemService.ListIngredientListItemByRecipe(request.RecipeId);
            }
        }

    }
}