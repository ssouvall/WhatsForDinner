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
    public class Create
    {
        public class Command : IRequest
        {
            public IngredientListItem IngredientListItem { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IIngredientListItemService _ingredientListItemService;
            public Handler(IIngredientListItemService ingredientListItemService)
            {
                _ingredientListItemService = ingredientListItemService;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _ingredientListItemService.CreateIngredientListItem(request.IngredientListItem);
                return Unit.Value;
            }
        }
        
    }
}