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
    public class CreateBulk
    {
        public class Command : IRequest
        {
            public List<IngredientListItem> IngredientListItems { get; set; }
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
                await _ingredientListItemService.CreateBulk(request.IngredientListItems);
                return Unit.Value;
            }
        }
        
    }
}